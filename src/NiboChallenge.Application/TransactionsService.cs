using System;
using System.Collections.Generic;
using NiboChallenge.Domain.Entities;
using NiboChallenge.DomainServices;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.Application
{
    public class TransactionsService: ITransactionsService
    {
        ITransactionDomainService _domainService;

        public TransactionsService(ITransactionDomainService domainService)
        {
            _domainService = domainService;
        }

        public void Add(ICollection<TransactionDTO> transactions)
        {
            _domainService.Add(transactions);
        }

        public IEnumerable<TransactionDTO> Get()
        {
            return _domainService.GetAllTransactions();
        }

        public IEnumerable<TransactionDTO> GetById(string id)
        {
            return _domainService.GetFilteredTransactions(x => x.DatePosted == id);
        }
    }
}
