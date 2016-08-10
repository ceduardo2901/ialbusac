using System.Collections.Generic;

using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class ResumenDiario : DocumentoResumen
    {
        public List<GrupoResumen> Resumenes { get; set; }
    }
}
