using System;
namespace NiboChallenge.Domain.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRS
    {
        public ushort TRNUID { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTATUS STATUS { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTMTRS STMTRS { get; set; }
    }
}
