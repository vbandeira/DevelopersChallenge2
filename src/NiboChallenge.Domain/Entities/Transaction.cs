using System;
namespace NiboChallenge.Domain.Entities
{
    public class Transaction
    {
        public TransactionType Type { get; set; }

        public string DatePosted { get; set; }

        public decimal TransactionAmmount { get; set; }

        public string Memo { get; set; }
    }

    public enum TransactionType
    {
        CREDIT,
        DEBIT
    }
}
