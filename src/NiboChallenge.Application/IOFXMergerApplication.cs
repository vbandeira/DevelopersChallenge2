using System;
using System.Collections.Generic;
using System.IO;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.Application
{
    public interface IOFXMergerApplication
    {
        IEnumerable<TransactionDTO> ImportFiles(params string[] filesContent);
        IEnumerable<TransactionDTO> ImportFiles(Stream fileStream);
        void SaveTransactions(IEnumerable<Transaction> transactions);
    }
}
