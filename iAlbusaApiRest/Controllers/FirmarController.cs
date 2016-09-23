﻿using System;
using System.Web.Http;
using ialbusacpr.ialbusac;

using ialbusacpr.ialbusac.Models;

namespace iAlbusaApiRest.Controllers
{
    public class FirmarController : ApiController
    {

        public FirmadoResponse Post([FromBody]FirmadoRequest request)
        {
            var response = new FirmadoResponse();

            try
            {
                var serializador = new SerializadorApi
                {
                    RutaCertificadoDigital = request.CertificadoDigital,
                    PasswordCertificado = request.PasswordCertificado,
                    TipoDocumento = request.UnSoloNodoExtension ? 0 : 1
                };

                response.TramaXmlFirmado = serializador.FirmarXml(request.TramaXmlSinFirma);
                response.ResumenFirma = serializador.DigestValue;
                response.ValorFirma = serializador.ValorFirma;
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return response;
        }

    }
}
