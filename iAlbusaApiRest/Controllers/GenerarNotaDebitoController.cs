using System;

using System.Web.Http;
using ialbusacpr.ialbusac;

using ialbusacpr.ialbusac.Models;

namespace iAlbusaApiRest.Controllers
{
    public class GenerarNotaDebitoController : ApiController
    {

        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var notaDebito = Generador.GenerarDebitNote(documento);

                var serializador = new Serializador();

                response.TramaXmlSinFirma = serializador.GenerarXml(notaDebito);
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
