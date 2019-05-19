using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(IEnumerable<TransactionDTO> transactions)
        {
            _domainService.Add(transactions);
        }

        public IEnumerable<TransactionDTO> Get()
        {
            return _domainService.GetAllTransactions();
        }

        public TransactionDTO GetById(int id)
        {
            return _domainService.GetFilteredTransactions(x => x.Id == id).First();
        }
    }
}
