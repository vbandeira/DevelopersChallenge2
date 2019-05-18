using System;
using System.Collections.Generic;
using System.Linq;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DataAccess.Repositories;
using NiboChallenge.Infrastructure.DTOs;
using NiboChallenge.Infrastructure.Mappers;

namespace NiboChallenge.DomainServices
{
    public class TransactionDomainService: ITransactionDomainService
    {
        ITransactionRepository _repository;

        public TransactionDomainService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            return _repository.Get().Select(TransactionMapper.ToTransactionDTO);
        }

        public IEnumerable<TransactionDTO> GetFilteredTransactions(Func<Transaction, bool> filter)
        {
            return _repository.Get(filter).Select(TransactionMapper.ToTransactionDTO);
        }
    }
}
