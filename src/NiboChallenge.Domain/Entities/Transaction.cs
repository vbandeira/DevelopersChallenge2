using System;
using System.Collections.Generic;

namespace NiboChallenge.Domain.Entities
{
    public class Transaction : IEquatable<Transaction>
    {
        public int Id { get; set; }

        public TransactionType Type { get; set; }

        public DateTime DatePosted { get; set; }

        public decimal TransactionAmount { get; set; }

        public string Memo { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Transaction)) return false;
            Transaction other = (Transaction)obj;
            return this.DatePosted == other.DatePosted &&
                this.Memo == other.Memo &&
                this.TransactionAmount == other.TransactionAmount &&
                this.Type == other.Type;
        }

        public bool Equals(Transaction other)
        {
            return other != null &&
                   Type == other.Type &&
                   DatePosted == other.DatePosted &&
                   TransactionAmount == other.TransactionAmount &&
                   Memo == other.Memo;
        }

        public override int GetHashCode()
        {
            var hashCode = 1253119681;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + DatePosted.GetHashCode();
            hashCode = hashCode * -1521134295 + TransactionAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Memo);
            return hashCode;
        }
    }

    public enum TransactionType
    {
        CREDIT,
        DEBIT
    }
}
