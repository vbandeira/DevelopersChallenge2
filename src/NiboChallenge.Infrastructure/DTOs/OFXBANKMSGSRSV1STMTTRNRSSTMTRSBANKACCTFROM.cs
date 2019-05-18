using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKACCTFROM
    {
        [XmlElement("BANKID")]
        public virtual ushort BankId { get; set; }

        [XmlElement("ACCTID")]
        public virtual ulong AccountId { get; set; }

        [XmlElement("ACCTTYPE")]
        public virtual string AccountType { get; set; }
    }
}
