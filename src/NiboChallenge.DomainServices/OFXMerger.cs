using System;
using System.Collections.Generic;
using System.Linq;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.Entities;
using NiboChallenge.Infrastructure.Mappers;

namespace NiboChallenge.DomainServices
{
    public class OFXMerger: IOFXMerger
    {
        public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();

        /// <summary>
        /// Gets the transactions from OFX files, detect the new ones and add them to collection.
        /// </summary>
        /// <param name="ofxDocuments">Ofx documents.</param>
        public void AddTransactionsAndMerge(params OFXDocument[] ofxDocuments)
        {
            foreach (OFXDocument document in ofxDocuments)
            {
                IEnumerable<Transaction> transactions = ExtractTransactions(document);
                IEnumerable<Transaction> newTransactions = transactions.Where(t => !Transactions.Contains(t));
                (Transactions as List<Transaction>).AddRange(newTransactions);
            }
        }

        /// <summary>
        /// Extract transactions from OFX document and map them to Transaction object of the domain
        /// </summary>
        /// <returns>The transactions.</returns>
        /// <param name="ofxDocument">Ofx document.</param>
        private IEnumerable<Transaction> ExtractTransactions(OFXDocument ofxDocument)
        {
            return ofxDocument.Bank.STMTSTRNRS.StmTrs.TranList.Transactions.Select(TransactionMapper.ToTransaction);
        }
    }
}
