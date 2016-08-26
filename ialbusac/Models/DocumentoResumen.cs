using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public abstract class DocumentoResumen
    {
        public Contribuyente Emisor { get; set; }
        public string IdDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string FechaReferencia { get; set; }

        public DocumentoResumen() {

            Emisor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
        }

    }
}
