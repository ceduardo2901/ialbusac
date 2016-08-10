using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class FirmadoRequest
    {
        public string CertificadoDigital { get; set; }
        public string PasswordCertificado { get; set; }
        public string TramaXmlSinFirma { get; set; }
        public bool UnSoloNodoExtension { get; set; }
    }
}
