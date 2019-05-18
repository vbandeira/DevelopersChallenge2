using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST
    {
        [XmlElement("DTSTART")]
        public virtual string DateStart { get; set; }

        [XmlElement("DTEND")]
        public virtual string DateEnd { get; set; }

        [XmlElement("STMTTRN")]
        public virtual OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN[] Transactions { get; set; }
    }
}
