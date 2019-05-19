using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.Entities;

namespace NiboChallenge.DomainServices
{
    public interface IOFXMerger
    {
        /// <summary>
        /// Property with the list of processed Transactions
        /// </summary>
        IList<Transaction> Transactions { get; }

        /// <summary>
        /// Parses the OFX Documents supplied and merge them, removing duplicates
        /// </summary>
        /// <param name="ofxDocuments">Collection of OFX Documents</param>
        void AddTransactionsAndMerge(params OFXDocument[] ofxDocuments);
    }
}
