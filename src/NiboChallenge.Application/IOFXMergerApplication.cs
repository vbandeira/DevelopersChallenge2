using System;
using System.Collections.Generic;
using System.IO;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;

namespace NiboChallenge.Application
{
    public interface IOFXMergerApplication
    {
        /// <summary>
        /// Import multiple files and process them to consolidate the information
        /// </summary>
        /// <param name="filesContent">String content of the file</param>
        /// <returns>Collection of processed Transactions</returns>
        IEnumerable<TransactionDTO> ImportFiles(params string[] filesContent);

        /// <summary>
        /// Import a single file and process it against previous files imported
        /// </summary>
        /// <param name="fileStream">Stream for the file</param>
        /// <returns>Collection of processed Transactions</returns>
        IEnumerable<TransactionDTO> ImportFiles(Stream fileStream);
    }
}
