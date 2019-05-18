using System;
using Microsoft.EntityFrameworkCore;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DataAccess.Mappers;

namespace NiboChallenge.Infrastructure.DataAccess.Context
{
    public class TransactionContext:DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = new TransactionMapper(modelBuilder.Entity<Transaction>());
        }
    }
}
