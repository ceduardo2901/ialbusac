﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using Ionic.Zip;
using ialbusacpr.ialbusac;
using ialbusacpr.ialbusac.Estructuras;
using ialbusacpr.ialbusac.Models;

namespace iAlbusaApiRest.Controllers
{
    public class EnviarDocumentoController : ApiController
    {
        public EnviarDocumentoResponse Post([FromBody]EnviarDocumentoRequest request)
        {
            var response = new EnviarDocumentoResponse();

            var serializador = new Serializador();
            var nombreArchivo = $"{request.Ruc}-{request.TipoDocumento}-{request.IdDocumento}";

            var tramaZip = serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

            var conexionSunat = new ConexionSunatApi(new ConexionSunatApi.Parametros
            {
                Ruc = request.Ruc,
                UserName = request.UsuarioSol,
                Password = request.ClaveSol,
                EndPointUrl = request.EndPointUrl
            });

            var resultado = conexionSunat.EnviarDocumento(tramaZip, $"{nombreArchivo}.zip");

            if (resultado.Item2)
            {
                var returnByte = Convert.FromBase64String(resultado.Item1);
                using (var memRespuesta = new MemoryStream(returnByte))
                {
                    using (var zipFile = ZipFile.Read(memRespuesta))
                    {
                        foreach (var entry in zipFile.Entries)
                        {
                            if (!entry.FileName.EndsWith(".xml")) continue;
                            using (var ms = new MemoryStream())
                            {
                                entry.Extract(ms);
                                ms.Position = 0;
                                var responseReader = new StreamReader(ms);
                                var responseString = responseReader.ReadToEnd();
                                try
                                {
                                    var xmlDoc = new XmlDocument();
                                    xmlDoc.LoadXml(responseString);

                                    var xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);

                                    xmlnsManager.AddNamespace("ar", EspacioNombres.ar);
                                    xmlnsManager.AddNamespace("cac", EspacioNombres.cac);
                                    xmlnsManager.AddNamespace("cbc", EspacioNombres.cbc);

                                    response.CodigoRespuesta = xmlDoc.SelectSingleNode(EspacioNombres.nodoResponseCode,
                                        xmlnsManager)?.InnerText;

                                    response.MensajeRespuesta = xmlDoc.SelectSingleNode(EspacioNombres.nodoDescription,
                                        xmlnsManager)?.InnerText;
                                    response.TramaZipCdr = resultado.Item1;
                                    response.Exito = true;

                                }
                                catch (Exception ex)
                                {
                                    response.MensajeError = ex.Message;
                                    response.Pila = ex.StackTrace;
                                    response.Exito = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                response.Exito = true;
                response.MensajeRespuesta = resultado.Item1;
            }

            return response;
        }
    }
}
