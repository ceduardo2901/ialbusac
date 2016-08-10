using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class DocumentoBaja : DocumentoResumenDetalle
    {
        public string Correlativo { get; set; }
        public string MotivoBaja { get; set; }
    }
}
