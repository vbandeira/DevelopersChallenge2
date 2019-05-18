using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    [XmlRoot("OFX")]
    public class OFXDocument
    {
        [XmlElement("SIGNONMSGSRSV1")]
        public virtual OFXSIGNONMSGSRSV1 SIGNON { get; set; }

        [XmlElement("BANKMSGSRSV1")]
        public virtual OFXBANKMSGSRSV1 Bank { get; set; }
    }
}
