using System;
namespace NiboChallenge.Infrastructure.DTOs
{
    public class TransactionDTO
    {
        public string Type { get; set; }

        public string DatePosted { get; set; }

        public decimal TransactionAmount { get; set; }

        public string Memo { get; set; }
    }
}
