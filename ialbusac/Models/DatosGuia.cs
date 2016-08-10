﻿using System;
using System.Collections.ObjectModel;

namespace ialbusacpr.ialbusac.Models
{
    public class DatosGuia
    {
        public Contribuyente DireccionDestino { get; set; }
        public Contribuyente DireccionOrigen { get; set; }
        public string RucTransportista { get; set; }
        public string TipoDocTransportista { get; set; }
        public string NombreTransportista { get; set; }
        public string NroLicenciaConducir { get; set; }
        public string PlacaVehiculo { get; set; }
        public string CodigoAutorizacion { get; set; }
        public string MarcaVehiculo { get; set; }
        public string ModoTransporte { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PesoBruto { get; set; }

        public DatosGuia()
        {
            DireccionDestino = new Contribuyente();
            DireccionOrigen = new Contribuyente();
        }

    }
}
