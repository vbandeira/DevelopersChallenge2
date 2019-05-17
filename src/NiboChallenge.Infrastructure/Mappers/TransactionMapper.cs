using System;
using NiboChallenge.Domain.Entities;

namespace NiboChallenge.Infrastructure.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction ToTransaction(this OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN transactionDTO)
        {
            return new Transaction
            {
                Memo = transactionDTO.MEMO,
                TransactionAmmount = transactionDTO.TRNAMT,
                Type = transactionDTO.TRNTYPE.ToUpper().Trim() == "CREDIT" ? TransactionType.CREDIT : TransactionType.DEBIT,
                DatePosted = transactionDTO.DTPOSTED
            };
        }
    }
}
