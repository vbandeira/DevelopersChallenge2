using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiboChallenge.Domain.Entities;

namespace NiboChallenge.Infrastructure.DataAccess.Mappers
{
    public class TransactionMapper
    {
        public TransactionMapper(EntityTypeBuilder<Transaction> transactionBuilder)
        {
            transactionBuilder.HasKey(t => t.Id);
            transactionBuilder.Property(t => t.DatePosted).IsRequired();
            transactionBuilder.Property(t => t.Memo).IsRequired();
            transactionBuilder.Property(t => t.TransactionAmount).IsRequired();
            transactionBuilder.Property(t => t.Type).IsRequired();
        }
    }
}
