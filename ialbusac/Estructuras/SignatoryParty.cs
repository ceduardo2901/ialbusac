using System;

namespace ialbusac.Estructuras
{
    [Serializable]
    public class SignatoryParty
    {
        public PartyIdentification PartyIdentification { get; set; }
        public PartyName PartyName { get; set; }


        public SignatoryParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyName = new PartyName();
        }
    }
}