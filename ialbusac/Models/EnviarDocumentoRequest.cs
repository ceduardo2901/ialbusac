using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
        public string TramaXmlFirmado { get; set; }
    }
}
