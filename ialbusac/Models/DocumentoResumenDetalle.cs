using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public abstract class DocumentoResumenDetalle
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
    }
}
