﻿using System;

namespace ialbusacpr.ialbusac.Estructuras
{
    [Serializable]
    public class SunatRoadTransport
    {
        public string LicensePlateId { get; set; }
        public string TransportAuthorizationCode { get; set; }
        public string BrandName { get; set; }
    }
}