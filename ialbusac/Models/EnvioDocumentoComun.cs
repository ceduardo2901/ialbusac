﻿using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public abstract class EnvioDocumentoComun
    {
        public string Ruc { get; set; }
        public string UsuarioSol { get; set; }
        public string ClaveSol { get; set; }
        public string TipoDocumento { get; set; }
        public string IdDocumento { get; set; }
        public string EndPointUrl { get; set; }
    }
}
