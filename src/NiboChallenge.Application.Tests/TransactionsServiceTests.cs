using System;
using System.Collections.Generic;
using Moq;
using NiboChallenge.Domain.Entities;
using NiboChallenge.DomainServices;
using NiboChallenge.Infrastructure.DTOs;
using Xunit;

namespace NiboChallenge.Application.Tests
{
    public class TransactionsServiceTests
    {
        TransactionsService _service;
        Mock<ITransactionDomainService> _domainService;

        public TransactionsServiceTests()
        {
            _domainService = new Mock<ITransactionDomainService>();

            _domainService.Setup(x => x.Add(It.IsAny<IEnumerable<TransactionDTO>>()));

            _service = new TransactionsService(_domainService.Object);
        }

        [Fact]
        public void ShouldAddTransaction()
        {
            // Arrange
            Mock<TransactionDTO> transactionDTO = new Mock<TransactionDTO>();

            // Act
            _service.Add(new TransactionDTO[] { transactionDTO.Object });

            // Assert
            _domainService.Verify(x => x.Add(It.IsAny<ICollection<TransactionDTO>>()), Times.Once);
        }

        [Fact]
        public void ShouldGet()
        {
            // Arrange
            _domainService.Setup(x => x.GetAllTransactions()).Returns(new TransactionDTO[] { new Mock<TransactionDTO>().Object, new Mock<TransactionDTO>().Object });

            // Act
            var result = _service.Get();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            _domainService.Verify(x => x.GetAllTransactions(), Times.Once);
        }

        [Fact]
        public void ShouldGetById()
        {
            // Arrange
            _domainService.Setup(x => x.GetFilteredTransactions(It.IsAny<Func<Transaction,bool>>())).Returns(new TransactionDTO[] { new Mock<TransactionDTO>().Object, new Mock<TransactionDTO>().Object });

            // Act
            var result = _service.GetById(1);

            // Assert
            Assert.NotNull(result);
            _domainService.Verify(x => x.GetFilteredTransactions(It.IsAny<Func<Transaction, bool>>()), Times.Once);

        }
    }
}
