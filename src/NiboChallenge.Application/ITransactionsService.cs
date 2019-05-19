using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.Application
{
    public interface ITransactionsService
    {
        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns>Collection of Transaction DTOs</returns>
        IEnumerable<TransactionDTO> Get();

        /// <summary>
        /// Get the transaction with the supplied I
        /// </summary>
        /// <param name="id">Id of the transaction</param>
        /// <returns>Collection of Transaction DTOs</returns>
        TransactionDTO GetById(int id);

        /// <summary>
        /// Adds a collection of new transactions
        /// </summary>
        /// <param name="transactions">Collection of new transactions</param>
        void Add(IEnumerable<TransactionDTO> transactions);
    }
}
