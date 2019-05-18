using System;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;
using NiboChallenge.Infrastructure.Entities;

namespace NiboChallenge.Infrastructure.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction ToTransaction(this OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN transactionDTO)
        {
            return new Transaction
            {
                Memo = transactionDTO.Memo,
                TransactionAmount = transactionDTO.TransactionAmount,
                Type = transactionDTO.TransactionType.ToUpper().Trim() == "CREDIT" ? TransactionType.CREDIT : TransactionType.DEBIT,
                DatePosted = transactionDTO.DatePosted //TODO: Convert to DateTime
            };
        }

        public static TransactionDTO ToTransactionDTO(this Transaction transaction)
        {
            return new TransactionDTO
            {
                Memo = transaction.Memo,
                DatePosted = transaction.DatePosted,
                TransactionAmount = transaction.TransactionAmount,
                Type = transaction.Type.ToString()
            };
        }
    }
}
