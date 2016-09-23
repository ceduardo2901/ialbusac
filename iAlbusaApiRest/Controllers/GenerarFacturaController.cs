using System;
using System.Web.Http;
using ialbusacpr.ialbusac;

using ialbusacpr.ialbusac.Models;

namespace iAlbusaApiRest.Controllers
{
    public class GenerarFacturaController : ApiController
    {
        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = Generador.GenerarInvoice(documento);

                var serializador = new Serializador();

                response.TramaXmlSinFirma = serializador.GenerarXml(invoice);
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
