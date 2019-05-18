using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTATUS
    {
        [XmlElement("CODE")]
        public virtual byte Code { get; set; }

        [XmlElement("SEVERITY")]
        public virtual string Severity { get; set; }
    }
}
