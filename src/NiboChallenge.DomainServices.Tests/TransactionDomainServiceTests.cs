using System;
using System.Collections.Generic;
using Moq;
using NiboChallenge.Infrastructure.DataAccess.Repositories;
using NiboChallenge.Domain.Entities;
using Xunit;
using System.Linq;
using NiboChallenge.Infrastructure.DTOs;
using System.Linq.Expressions;

namespace NiboChallenge.DomainServices.Tests
{
    public class TransactionDomainServiceTests
    {
        private readonly TransactionDomainService _domainService;

        private readonly Mock<ITransactionRepository> _repository;
        private List<Transaction> transactions = new List<Transaction>();

        public TransactionDomainServiceTests()
        {
            _repository = new Mock<ITransactionRepository>();
            _repository.Setup(x => x.Add(
                    It.IsAny<IEnumerable<Transaction>>()
                ))
                .Callback<IEnumerable<Transaction>>((transaction) => transactions.AddRange(transaction));

            _repository.Setup(x => x.Get())
                .Returns(transactions.AsQueryable());

            _repository.Setup(x => x.Get(It.IsAny<Func<Transaction, bool>>()))
                .Returns<Func<Transaction,bool>>((where) => transactions.Where(where).AsQueryable());

            _domainService = new TransactionDomainService(_repository.Object);
        }

        [Fact]
        public void ShouldAddTransaction()
        {
            // Arrange
            TransactionDTO transaction1 = new TransactionDTO
            {
                DatePosted = DateTime.Now.AddHours(-1),
                Memo = "Transaction 1",
                TransactionAmount = 20,
                Type = "CREDIT"
            };

            TransactionDTO transaction2 = new TransactionDTO
            {
                DatePosted = DateTime.Now,
                Memo = "Transaction 2",
                TransactionAmount = 10,
                Type = "DEBIT"
            };

            // Act
            _domainService.Add(new TransactionDTO[] { transaction1, transaction2 });

            // Assert
            var result = _domainService.GetAllTransactions();
            Assert.Equal(2, result.Count());

            _repository.Verify(x => x.Add(
                    It.IsAny<IEnumerable<Transaction>>()
                ), Times.Once);

            // Cleanup
            transactions.Clear();
        }

        [Fact]
        public void ShouldGetAllTransactions()
        {
            // Arrange
            TransactionDTO transaction1 = new TransactionDTO
            {
                DatePosted = DateTime.Now.AddHours(-1),
                Memo = "Transaction 1",
                TransactionAmount = 20,
                Type = "CREDIT"
            };

            TransactionDTO transaction2 = new TransactionDTO
            {
                DatePosted = DateTime.Now,
                Memo = "Transaction 2",
                TransactionAmount = 10,
                Type = "DEBIT"
            };
            _domainService.Add(new TransactionDTO[] { transaction1, transaction2 });

            // Act
            var result = _domainService.GetAllTransactions();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.IsAssignableFrom<IEnumerable<TransactionDTO>>(result);

            _repository.Verify(x => x.Get(), Times.Once);

            // Cleanup
            transactions.Clear();
        }

        [Fact]
        public void ShouldGetFilteredTransactions()
        {
            // Arrange
            TransactionDTO transaction1 = new TransactionDTO
            {
                DatePosted = DateTime.Now.AddHours(-1),
                Memo = "Transaction 1",
                TransactionAmount = 20,
                Type = "CREDIT"
            };

            TransactionDTO transaction2 = new TransactionDTO
            {
                DatePosted = DateTime.Now,
                Memo = "Transaction 2",
                TransactionAmount = 10,
                Type = "DEBIT"
            };
            _domainService.Add(new TransactionDTO[] { transaction1, transaction2 });

            var result = _domainService.GetFilteredTransactions(x => x.Type == TransactionType.CREDIT);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<IEnumerable<TransactionDTO>>(result);
            _repository.Verify(x => x.Get(It.IsAny<Func<Transaction, bool>>()), Times.Once);
                
            // Cleanup
            transactions.Clear();
        }
    }
}
