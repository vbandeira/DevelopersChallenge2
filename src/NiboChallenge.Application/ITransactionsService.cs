using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.Application
{
    public interface ITransactionsService
    {
        IEnumerable<TransactionDTO> Get();
        IEnumerable<TransactionDTO> GetById(string id);
        void Add(ICollection<TransactionDTO> transactions);
    }
}
