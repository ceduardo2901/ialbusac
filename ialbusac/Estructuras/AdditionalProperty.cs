﻿using System;

namespace ialbusacpr.ialbusac.Estructuras
{
    [Serializable]
    public class AdditionalProperty
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}