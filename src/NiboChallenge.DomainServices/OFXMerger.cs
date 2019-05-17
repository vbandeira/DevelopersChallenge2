using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.Entities;

namespace NiboChallenge.DomainServices
{
    public class OFXMerger: IOFXMerger
    {
        public ICollection<Transaction> Transactions { get; private set; }

        public void AddTransactions(params OFX[] ofxDocuments)
        {
            //TODO: Receive OFX document, extract transactions and merge with existing ones
            throw new NotImplementedException();
        }
    }
}
