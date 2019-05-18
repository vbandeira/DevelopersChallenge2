using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.DomainServices
{
    public interface ITransactionDomainService
    {
        IEnumerable<TransactionDTO> GetAllTransactions();
        IEnumerable<TransactionDTO> GetFilteredTransactions(Func<Transaction, bool> filter);
    }
}
