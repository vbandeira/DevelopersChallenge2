using System;
using NiboChallenge.Infrastructure.Entities;
using Xunit;
using Moq;

namespace NiboChallenge.DomainServices.Tests
{
    public class OFXMergerTests
    {
        [Fact]
        public void ShouldMergeTransactions()
        {
            // Arrange
            Mock<OFXDocument> mockDocument1 = new Mock<OFXDocument>();
            Mock<OFXDocument> mockDocument2 = new Mock<OFXDocument>();

            mockDocument1.SetupGet(x => x.Bank.STMTSTRNRS.StmTrs.TranList.Transactions).Returns(
                new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN[]
                {
                    new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
                    {
                        TransactionType = "DEBIT",
                        DatePosted = "20140203100000[-03:EST]",
                        TransactionAmount = (decimal)-140.00,
                        Memo = "CXE     001958 SAQUE"
                    },
                    new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
                    {
                        TransactionType = "DEBIT",
                        DatePosted = "20140204100000[-03:EST]",
                        TransactionAmount = (decimal)-4000.00,
                        Memo = "TBI 0304.40719-0     C/C"
                    }
                });

            mockDocument2.SetupGet(x => x.Bank.STMTSTRNRS.StmTrs.TranList.Transactions).Returns(
                new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN[]
                {
                    new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
                    {
                        TransactionType = "DEBIT",
                        DatePosted = "20140203100000[-03:EST]",
                        TransactionAmount = (decimal)-140.00,
                        Memo = "CXE     001958 SAQUE"
                    },
                    new OFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
                    {
                        TransactionType = "DEBIT",
                        DatePosted = "20140204100000[-03:EST]",
                        TransactionAmount = (decimal)-39.00,
                        Memo = "TAR PACOTE MENS    01/14"
                    }
                });

            // Act
            OFXMerger merger = new OFXMerger();
            merger.AddTransactions(mockDocument1.Object, mockDocument2.Object);

            // Assert
            Assert.NotNull(merger.Transactions);
            Assert.True(merger.Transactions.Count == 3);
        }
    }
}
