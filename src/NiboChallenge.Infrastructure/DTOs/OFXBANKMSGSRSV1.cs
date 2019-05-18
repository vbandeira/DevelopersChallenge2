using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1
    {
        [XmlElement("STMTTRNRS")]
        public virtual OFXBANKMSGSRSV1STMTTRNRS STMTSTRNRS { get; set; }
    }
}
