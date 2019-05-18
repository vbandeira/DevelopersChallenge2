using System;
using Microsoft.EntityFrameworkCore;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DataAccess.Repositories;

namespace NiboChallenge.Infrastructure.DataAccess.Repositories
{
    public class TransactionRepository: GenericRepository<Transaction>, ITransactionRepository
    {

        public TransactionRepository(DbContext context):base(context, true){}
    }
}
