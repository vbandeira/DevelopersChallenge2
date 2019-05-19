using System;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DTOs;
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

        [Fact]
        public void ShouldConvertTransactionToTransactionDTO()
        {
            // Arrange
            Transaction transaction = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = new DateTime(2014, 02, 03, 10, 0, 0),
                TransactionAmount = (Decimal)(-140.00),
                Memo = "CXE     001958 SAQUE"
            };

            // Act
            var dto = transaction.ToTransactionDTO();

            // Assert
            Assert.NotNull(dto);
            Assert.IsType<TransactionDTO>(dto);
            Assert.Equal("DEBIT", dto.Type);
            Assert.Equal(-140, dto.TransactionAmount);
            Assert.Equal("CXE     001958 SAQUE", dto.Memo);
            Assert.Equal(new DateTime(2014, 02, 03, 10, 0, 0), dto.DatePosted);
        }

        [Fact]
        public void ShouldConvertTransactionDTOToTransaction()
        {
            // Arrange
            TransactionDTO transactionDTO = new TransactionDTO
            {
                Type = "CREDIT",
                DatePosted = new DateTime(2014, 02, 03, 10, 0, 0),
                TransactionAmount = (Decimal)(-140.00),
                Memo = "CXE     001958 SAQUE"
            };

            // Act
            var transaction = transactionDTO.ToTransaction();

            // Assert
            Assert.NotNull(transaction);
            Assert.IsType<Transaction>(transaction);
            Assert.Equal(TransactionType.CREDIT, transaction.Type);
            Assert.Equal(-140, transaction.TransactionAmount);
            Assert.Equal("CXE     001958 SAQUE", transaction.Memo);
            Assert.Equal(new DateTime(2014, 02, 03, 10, 0, 0), transaction.DatePosted);
        }

    }
}
