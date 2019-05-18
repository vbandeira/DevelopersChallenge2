using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
    {
        [XmlElement("TRNTYPE")]
        public virtual string TransactionType { get; set; }

        [XmlElement("DTPOSTED")]
        public virtual string DatePosted { get; set; }

        [XmlElement("TRNAMT")]
        public virtual decimal TransactionAmount { get; set; }

        [XmlElement("MEMO")]
        public virtual string Memo { get; set; }
    }
}
