using System;

namespace ialbusacpr.ialbusac.Estructuras
{
    [Serializable]
    public class PartyIdentification
    {
        public PartyIdentificationID ID { get; set; }

        public PartyIdentification()
        {
            ID = new PartyIdentificationID();
        }
    }
}