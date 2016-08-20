using System.Collections.Generic;

using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class ComunicacionBaja : DocumentoResumen
    {
        public List<DocumentoBaja> Bajas { get; set; }

    }
}
