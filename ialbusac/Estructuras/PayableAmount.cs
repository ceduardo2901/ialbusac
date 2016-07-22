using System;

namespace ialbusacpr.ialbusac.Estructuras
{
    [Serializable]
    public class PayableAmount
    {
        public string currencyID { get; set; }
        public decimal value { get; set; }
    }
}