using System;
using System.Xml.Serialization;

namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRSLEDGERBAL
    {
        [XmlElement("BALAMT")]
        public virtual decimal BalanceAmount { get; set; }

        [XmlElement("DTASOF")]
        public virtual string Date { get; set; }
    }
}
