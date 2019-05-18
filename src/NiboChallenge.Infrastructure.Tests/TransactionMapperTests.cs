using System;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.Entities;
using NiboChallenge.Infrastructure.Mappers;
using Xunit;

namespace NiboChallenge.Infrastructure.Tests
{
    public class TransactionMapperTests
    {
        public TransactionMapperTests()
        {
        }

        [Fact]
        public void ShouldConvertOFXObjectToTransaction()
        {
            // Arrange
            OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN ofxTransaction = new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
            {
                TransactionType = "DEBIT",
                DatePosted = "20140203100000[-03:EST]",
                TransactionAmount = (Decimal)(-140.00),
                Memo = "CXE     001958 SAQUE"
            };

            // Act
            var transaction = ofxTransaction.ToTransaction();

            // Assert
            Assert.NotNull(transaction);
            Assert.IsType<Transaction>(transaction);
            Assert.Equal(Domain.Entities.TransactionType.DEBIT, transaction.Type);
            Assert.Equal(-140, transaction.TransactionAmount);
            Assert.Equal("CXE     001958 SAQUE", transaction.Memo);
            Assert.Equal(new DateTime(2014, 02, 03, 10, 0, 0), transaction.DatePosted);
        }
    }
}
