﻿using System;
using System.Web.Http;
using ialbusacpr.ialbusac;
using ialbusacpr.ialbusac.Estructuras;
using ialbusacpr.ialbusac.Models;

namespace iAlbusaApiRest.Controllers
{
    public class GenerarComunicacionBajaController : ApiController
    {
        public DocumentoResponse Post([FromBody]ComunicacionBaja baja)
        {
            var response = new DocumentoResponse();

            try
            {
                var voidedDocument = Generador.GenerarVoidedDocuments(baja);

                var serializador = new Serializador();
                response.TramaXmlSinFirma = serializador.GenerarXml(voidedDocument);
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