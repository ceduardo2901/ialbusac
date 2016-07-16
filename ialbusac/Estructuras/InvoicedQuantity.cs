using System;

namespace ialbusac.Estructuras
{
    [Serializable]
    public class InvoicedQuantity
    {
        public string unitCode { get; set; }
        public decimal Value { get; set; }
    }
}