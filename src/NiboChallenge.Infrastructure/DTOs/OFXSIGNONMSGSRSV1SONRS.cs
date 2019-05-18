using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXSIGNONMSGSRSV1SONRS
    {
        [XmlElement("STATUS")]
        public virtual OFXSIGNONMSGSRSV1SONRSSTATUS Status { get; set; }

        [XmlElement("DTSERVER")]
        public virtual string DateServer { get; set; }

        [XmlElement("LANGUAGE")]
        public virtual string Language { get; set; }

    }
}
