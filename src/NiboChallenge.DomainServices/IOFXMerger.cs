using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.Entities;

namespace NiboChallenge.DomainServices
{
    public interface IOFXMerger
    {
        IList<Transaction> Transactions { get; }

        void AddTransactions(params OFXDocument[] ofxDocuments);
    }
}
