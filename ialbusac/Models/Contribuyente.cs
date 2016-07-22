﻿using System;

namespace ialbusac.ialbusac.Models
{
    [Serializable]
    public class Contribuyente
    {
        public string NroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreLegal { get; set; }
        public string NombreComercial { get; set; }
        public string Ubigeo { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }
}