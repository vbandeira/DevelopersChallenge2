using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRS
    {
        [XmlElement("CURDEF")]
        public virtual string CurDef { get; set; }

        [XmlElement("BANKACCTFROM")]
        public virtual OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKACCTFROM AcctFrom { get; set; }

        [XmlElement("BANKTRANLIST")]
        public virtual OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST TranList { get; set; }

        [XmlElement("LEDGERBAL")]
        public virtual OFXBANKMSGSRSV1STMTTRNRSSTMTRSLEDGERBAL LedgerBalance { get; set; }
    }
}
