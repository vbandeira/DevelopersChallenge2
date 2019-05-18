using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NiboChallenge.Domain.Entities;
using NiboChallenge.DomainServices;
using NiboChallenge.Infrastructure;
using NiboChallenge.Infrastructure.DTOs;
using NiboChallenge.Infrastructure.Entities;
using NiboChallenge.Infrastructure.Mappers;

namespace NiboChallenge.Application
{
    public class OFXMergerApplication: IOFXMergerApplication
    {
        IOFXMerger _ofxMerger;

        public OFXMergerApplication(IOFXMerger ofxMerger)
        {
            _ofxMerger = ofxMerger;
        }

        public IEnumerable<TransactionDTO> ImportFiles(params string[] filesContent)
        {
            IEnumerable<OFXDocument> ofxDocuments = OFXDocumentParser.Load(filesContent);
            _ofxMerger.AddTransactions(ofxDocuments.ToArray());
            return _ofxMerger.Transactions.Select(TransactionMapper.ToTransactionDTO).AsEnumerable();
        }

        public IEnumerable<TransactionDTO> ImportFiles(Stream fileStream)
        {
            IEnumerable<OFXDocument> ofxDocuments = OFXDocumentParser.Load(fileStream);
            _ofxMerger.AddTransactions(ofxDocuments.ToArray());
            return _ofxMerger.Transactions.Select(TransactionMapper.ToTransactionDTO).AsEnumerable();
        }


        public void SaveTransactions(IEnumerable<Transaction> transactions)
        {
            throw new NotImplementedException();
        }
    }
}
