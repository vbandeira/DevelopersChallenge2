using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRS
    {
        [XmlElement("TRNUID")]
        public virtual ushort TrnUid { get; set; }

        [XmlElement("STATUS")]
        public virtual OFXBANKMSGSRSV1STMTTRNRSSTATUS Status { get; set; }

        [XmlElement("STMTRS")]
        public virtual OFXBANKMSGSRSV1STMTTRNRSSTMTRS StmTrs { get; set; }
    }
}
