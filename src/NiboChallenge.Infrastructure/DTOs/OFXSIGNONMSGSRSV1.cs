using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{

    public class OFXSIGNONMSGSRSV1
    {
        [XmlElement("SONRS")]
        public virtual OFXSIGNONMSGSRSV1SONRS SONRS { get; set; }
    }
}
