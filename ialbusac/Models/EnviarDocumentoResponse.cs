using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class EnviarDocumentoResponse : RespuestaComun
    {
        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string TramaZipCdr { get; set; }
    }
}
