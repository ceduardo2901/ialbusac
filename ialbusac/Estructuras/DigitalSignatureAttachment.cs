﻿using System;

namespace ialbusac.Estructuras
{
    [Serializable]
    public class DigitalSignatureAttachment
    {
        public ExternalReference ExternalReference { get; set; }

        public DigitalSignatureAttachment()
        {
            ExternalReference = new ExternalReference();
        }
    }
}