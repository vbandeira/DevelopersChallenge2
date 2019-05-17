using System;
namespace NiboChallenge.Infrastructure.Entities
{
    public class OFXBANKMSGSRSV1STMTTRNRS
    {
        public ushort TRNUID { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTATUS STATUS { get; set; }

        public OFXBANKMSGSRSV1STMTTRNRSSTMTRS STMTRS { get; set; }
    }
}
