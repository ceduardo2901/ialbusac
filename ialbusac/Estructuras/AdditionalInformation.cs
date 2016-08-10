﻿using System;
using System.Collections.Generic;

namespace ialbusacpr.ialbusac.Estructuras
{
    [Serializable]
    public class AdditionalInformation
    {
        public List<AdditionalMonetaryTotal> AdditionalMonetaryTotals { get; set; }
        public List<AdditionalProperty> AdditionalProperties { get; set; }
        public SunatEmbededDespatchAdvice SunatEmbededDespatchAdvice { get; set; }
        public SunatTransaction SunatTransaction { get; private set; }

        public AdditionalInformation()
        {
            AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>();
            AdditionalProperties = new List<AdditionalProperty>();
            SunatEmbededDespatchAdvice = new SunatEmbededDespatchAdvice();
            SunatTransaction = new SunatTransaction();
        }
    }
}