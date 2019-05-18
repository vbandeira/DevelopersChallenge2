using System;
using System.Collections.Generic;
using System.Linq;
using NiboChallenge.Domain.Entities;
using NiboChallenge.DomainServices;
using NiboChallenge.Infrastructure;
using NiboChallenge.Infrastructure.Entities;

namespace NiboChallenge.Application
{
    public class OFXMergerApplication
    {
        IOFXMerger _ofxMerger;

        public OFXMergerApplication(IOFXMerger ofxMerger)
        {
            _ofxMerger = ofxMerger;
        }

        public void ImportFiles(params string[] filesContent)
        {
            IEnumerable<OFXDocument> ofxDocuments = OFXDocumentParser.Load(filesContent);
            _ofxMerger.AddTransactions(ofxDocuments.ToArray());
        }

        private void SaveTransactions(IEnumerable<Transaction> transactions)
        {

        }
    }
}
