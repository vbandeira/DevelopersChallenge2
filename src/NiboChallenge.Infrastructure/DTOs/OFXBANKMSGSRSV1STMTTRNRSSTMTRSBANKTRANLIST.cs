using System;
namespace NiboChallenge.Domain.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST
    {
        public string DTSTART { get; set; }

        public string DTEND { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN[] STMTTRN { get; set; }
    }
}
