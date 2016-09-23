using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ialbusacpr.ialbusac;
using ialbusacpr.ialbusac.Estructuras;
using ialbusacpr.ialbusac.Models;

namespace iAlbusaApiRest.Controllers
{
    public class GenerarResumenDiarioController : ApiController
    {
        public DocumentoResponse Post([FromBody] ResumenDiario resumen)
        {
            var response = new DocumentoResponse();
            try
            {
                var summary = Generador.GenerarSummaryDocuments(resumen);
                var serializador = new Serializador();
                response.TramaXmlSinFirma = serializador.GenerarXml(summary);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
            }

            return response;
        }
    }
}
