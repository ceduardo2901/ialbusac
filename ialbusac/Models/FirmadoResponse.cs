﻿using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class FirmadoResponse : RespuestaComun
    {
        public string TramaXmlFirmado { get; set; }
        public string ResumenFirma { get; set; }
        public string ValorFirma { get; set; }
    }
}
