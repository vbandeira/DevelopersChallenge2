using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.DomainServices
{
    public interface ITransactionDomainService
    {

        /// <summary>
        /// Get all transactions from Database
        /// </summary>
        /// <returns>Collection of Transactions</returns>
        IEnumerable<TransactionDTO> GetAllTransactions();

        /// <summary>
        /// Queries the Database for transactions using lambda to filter
        /// </summary>
        /// <param name="filter">Lambda expression to filter the collection</param>
        /// <returns>Collection of Transactions</returns>
        IEnumerable<TransactionDTO> GetFilteredTransactions(Func<Transaction, bool> filter);

        /// <summary>
        /// Adds a collection of transactions in the Database
        /// </summary>
        /// <param name="transactions">Collections of transactions to be added</param>
        void Add(IEnumerable<TransactionDTO> transactions);
    }
}
