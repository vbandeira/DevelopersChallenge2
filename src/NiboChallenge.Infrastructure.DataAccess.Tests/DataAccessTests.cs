using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NiboChallenge.Domain.Entities;
using NiboChallenge.Infrastructure.DataAccess.Context;
using NiboChallenge.Infrastructure.DataAccess.Repositories;
using Xunit;

namespace NiboChallenge.Infrastructure.DataAccess.Tests
{
    public class DataAccessTests:IDisposable
    {
        DbContextOptions<TransactionContext> _options;
        TransactionContext _context;
        TransactionRepository _repository;

        public DataAccessTests()
        {
            _options = new DbContextOptionsBuilder<TransactionContext>()
                .UseInMemoryDatabase(databaseName: "niboDatabase")
                .Options;
            _context = new TransactionContext(_options);
            _repository = new TransactionRepository(_context);
        }

        [Fact]
        public void ShouldGetAllTransactions()
        {
            // Arrange
            FillDummyData();

            // Act
            var result = _repository.Get();

            // Assert
            Assert.IsAssignableFrom<IQueryable<Transaction>>(result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());

            // CleanUp
            ClearData();
        }

        [Fact]
        public void ShouldGetFilteredTransactions()
        {
            // Arrange
            FillDummyData();

            // Act
            var result = _repository.Get(x => x.Type == TransactionType.CREDIT);

            // Assert
            Assert.IsAssignableFrom<IQueryable<Transaction>>(result);
            Assert.NotEmpty(result);
            Assert.Equal(1, result.Count());

            // CleanUp
            ClearData();
        }

        [Fact]
        public void ShouldAddOneTransaction()
        {
            // Arrange
            Transaction transaction1 = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = DateTime.Now,
                Memo = "Transaction1",
                TransactionAmount = -10
            };

            // Act
            _repository.Add(transaction1);

            // Assert
            IQueryable<Transaction> result = _repository.Get();
            Assert.NotEmpty(result);
            Assert.Equal(1, result.Count());
            Transaction transaction = result.First();
            Assert.Equal(transaction1.DatePosted, transaction.DatePosted);
            Assert.Equal(transaction1.Memo, transaction.Memo);
            Assert.Equal(transaction1.TransactionAmount, transaction.TransactionAmount);
            Assert.Equal(transaction1.Type, transaction.Type);

            // CleanUp
            ClearData();
        }

        [Fact]
        public void ShouldAddManyTransactions()
        {
            // Arrange
            Transaction transaction1 = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = DateTime.Now,
                Memo = "Transaction1",
                TransactionAmount = -10
            };

            Transaction transaction2 = new Transaction
            {
                Type = TransactionType.CREDIT,
                DatePosted = DateTime.Now.AddDays(-1),
                Memo = "Transaction2",
                TransactionAmount = 30
            };

            // Act
            _repository.Add(new Transaction[] { transaction1, transaction2 });

            // Assert
            IQueryable<Transaction> result = _repository.Get();
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Transaction transaction = result.First();
            Assert.Equal(transaction1.DatePosted, transaction.DatePosted);
            Assert.Equal(transaction1.Memo, transaction.Memo);
            Assert.Equal(transaction1.TransactionAmount, transaction.TransactionAmount);
            Assert.Equal(transaction1.Type, transaction.Type);

            transaction = result.Last();
            Assert.Equal(transaction2.DatePosted, transaction.DatePosted);
            Assert.Equal(transaction2.Memo, transaction.Memo);
            Assert.Equal(transaction2.TransactionAmount, transaction.TransactionAmount);
            Assert.Equal(transaction2.Type, transaction.Type);

            // CleanUp
            ClearData();
        }

        [Fact]
        public void ShouldUpdateTransaction()
        {
            // Arrange
            Transaction transaction1 = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = DateTime.Now,
                Memo = "Transaction1",
                TransactionAmount = -10
            };
            _repository.Add(transaction1);

            // Act
            Transaction updatedTransaction = _repository.Get().First();
            updatedTransaction.Memo = "Edited Transaction1";
            _repository.Update(updatedTransaction);

            // Assert
            Transaction result = _repository.Get().First();
            Assert.Equal(updatedTransaction.DatePosted, result.DatePosted);
            Assert.Equal(updatedTransaction.Memo, result.Memo);
            Assert.Equal(updatedTransaction.TransactionAmount, result.TransactionAmount);
            Assert.Equal(updatedTransaction.Type, result.Type);

            // CleanUp
            ClearData();
        }

        [Fact]
        public void ShouldDeleteTransaction()
        {
            // Arrange
            Transaction transaction1 = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = DateTime.Now,
                Memo = "Transaction1",
                TransactionAmount = -10
            };
            _repository.Add(transaction1);

            // Act
            Transaction transactionToDelete = _repository.Get().First();
            _repository.Delete(transactionToDelete);

            // Assert
            IQueryable<Transaction> result = _repository.Get();
            Assert.DoesNotContain(transactionToDelete, result);

            // CleanUp
            ClearData();
        }

        private void FillDummyData()
        {
            Transaction transaction1 = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = DateTime.Now,
                Memo = "Transaction1",
                TransactionAmount = -10
            };

            Transaction transaction2 = new Transaction
            {
                Type = TransactionType.CREDIT,
                DatePosted = DateTime.Now.AddDays(-1),
                Memo = "Transaction2",
                TransactionAmount = 30
            };

            Transaction transaction3 = new Transaction
            {
                Type = TransactionType.DEBIT,
                DatePosted = DateTime.Now.AddHours(-1),
                Memo = "Transaction3",
                TransactionAmount = -20
            };

            _repository.Add(new Transaction[] { transaction1, transaction2, transaction3 });
        }

        private void ClearData()
        {
            foreach (var transaction in _repository.Get())
            {
                _repository.Delete(transaction);
            }
        }

        public void Dispose()
            {
            _repository = null;
            _context = null;
        }
    }
}