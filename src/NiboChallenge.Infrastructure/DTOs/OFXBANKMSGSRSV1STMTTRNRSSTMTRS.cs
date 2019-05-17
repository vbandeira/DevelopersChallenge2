using System;
namespace NiboChallenge.Domain.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRS
    {
        public string CURDEF { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKACCTFROM BANKACCTFROM { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST BANKTRANLIST { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTMTRSLEDGERBAL LEDGERBAL { get; set; }
    }
}
