using System;
namespace NiboChallenge.Domain.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
    {
        public string TRNTYPE { get; set; }

        public string DTPOSTED { get; set; }

        public decimal TRNAMT { get; set; }

        public string MEMO { get; set; }
    }
}
