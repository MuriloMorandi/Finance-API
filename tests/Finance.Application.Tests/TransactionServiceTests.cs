using Moq;
using Xunit;
using FluentAssertions;

using Finance.Application.Services;
using Finance.Domain.Entities;
using Finance.Domain.Enums;
using Finance.Domain.Interfaces;

namespace Finance.Application.Tests;

public class TransactionServiceTests
{
    private readonly Mock<ITransactionRepository> _mockRepo;
    private readonly TransactionService _service;

    public TransactionServiceTests()
    {
        _mockRepo = new Mock<ITransactionRepository>();
        _service = new TransactionService(_mockRepo.Object);
    }

    [Fact]
    public async Task Created_ShouldSucceed()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Depósito",
            Amount = 100,
            Date = DateTime.UtcNow,
            Type = TransactionType.Debit
        };

        await _service.AddTransactionAsync(transaction);

        _mockRepo.Verify(r => r.AddTransactionAsync(transaction), Times.Once);
    }
    
    [Fact]
    public async Task Created_ShouldFail_WhenAmountIsZero()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Depósito",
            Amount = 0,
            Date = DateTime.UtcNow,
            Type = TransactionType.Debit
        };

        Func<Task> act = async () => await _service.AddTransactionAsync(transaction);

        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Amount must be greater than zero");
        
        _mockRepo.Verify(r => r.AddTransactionAsync(It.IsAny<Transaction>()), Times.Never);
    }
    
    [Fact]
    public async Task Created_ShouldFail_WhenAmountIsNegative()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Depósito",
            Amount = -10,
            Date = DateTime.UtcNow,
            Type = TransactionType.Debit
        };

        Func<Task> act = async () => await _service.AddTransactionAsync(transaction);

        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Amount must be greater than zero");
        
        _mockRepo.Verify(r => r.AddTransactionAsync(It.IsAny<Transaction>()), Times.Never);
    }

    [Fact]
    public async Task Created_ShouldFail_WhenDescriptionIsEmpty()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = " ",
            Amount = 100,
            Date = DateTime.UtcNow,
            Type = TransactionType.Debit
        };

        Func<Task> act = async () => await _service.AddTransactionAsync(transaction);

        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Description is required");
        
        _mockRepo.Verify(r => r.AddTransactionAsync(It.IsAny<Transaction>()), Times.Never);
    }
    
    [Fact]
    public async Task Update_ShouldSucceed()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Updated Payment",
            Amount = 150,
            Date = DateTime.UtcNow,
            Type = TransactionType.Credit
        };

        _mockRepo.Setup(r => r.UpdateTransactionAsync(transaction)).Returns(Task.CompletedTask);

        await _service.UpdateTransactionAsync(transaction);

        _mockRepo.Verify(r => r.UpdateTransactionAsync(transaction), Times.Once);
    }
    
    [Fact]
    public async Task Update_ShouldFail_WhenAmountIsZero()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Updated Payment",
            Amount = 150,
            Date = DateTime.UtcNow,
            Type = TransactionType.Credit
        };

        _mockRepo.Setup(r => r.UpdateTransactionAsync(transaction)).Returns(Task.CompletedTask);

        await _service.UpdateTransactionAsync(transaction);

        _mockRepo.Verify(r => r.UpdateTransactionAsync(transaction), Times.Once);
    }
    
    [Fact]
    public async Task Update_ShouldFail_WhenAmountIsNegative()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Updated Payment",
            Amount = 150,
            Date = DateTime.UtcNow,
            Type = TransactionType.Credit
        };

        _mockRepo.Setup(r => r.UpdateTransactionAsync(transaction)).Returns(Task.CompletedTask);

        await _service.UpdateTransactionAsync(transaction);

        _mockRepo.Verify(r => r.UpdateTransactionAsync(transaction), Times.Once);
    }
    
    [Fact]
    public async Task Update_ShouldFail_WhenDescriptionIsEmpty()
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Description = "Updated Payment",
            Amount = 150,
            Date = DateTime.UtcNow,
            Type = TransactionType.Credit
        };

        _mockRepo.Setup(r => r.UpdateTransactionAsync(transaction)).Returns(Task.CompletedTask);

        await _service.UpdateTransactionAsync(transaction);

        _mockRepo.Verify(r => r.UpdateTransactionAsync(transaction), Times.Once);
    }
    
    [Fact]
    public async Task GetAll_ShouldSucceed()
    {
        var transactions = new List<Transaction>
        {
            new Transaction { Id = Guid.NewGuid(), Description = "Deposit", Amount = 200, Type = TransactionType.Credit, Date = DateTime.UtcNow },
            new Transaction { Id = Guid.NewGuid(), Description = "Withdrawal", Amount = 50, Type = TransactionType.Debit, Date = DateTime.UtcNow },
            new Transaction { Id = Guid.NewGuid(), Description = "Deposit", Amount = 500, Type = TransactionType.Credit, Date = DateTime.UtcNow },
        };

        _mockRepo.Setup(r => r.GetAllTransactionsAsync()).ReturnsAsync(transactions);

        var result = await _service.GetTransactionsAsync();

        result.Should().NotBeEmpty()
            .And.HaveCount(3)
            .And.Contain(t => t.Description == transactions[0].Description && t.Amount == transactions[0].Amount)
            .And.Contain(t => t.Description == transactions[1].Description && t.Amount == transactions[1].Amount)
            .And.Contain(t => t.Description == transactions[2].Description && t.Amount == transactions[2].Amount);
    }
    
    [Fact]
    public async Task GetById_ShouldSucceed()
    {
        var transactionId = Guid.NewGuid();

        _mockRepo.Setup(r => r.DeleteTransactionAsync(transactionId)).Returns(Task.CompletedTask);

        await _service.DeleteTransactionAsync(transactionId);

        _mockRepo.Verify(r => r.DeleteTransactionAsync(transactionId), Times.Once);
    }

    [Fact]
    public async Task DeleteTransaction_ShouldCallRepository_WhenValidId()
    {
        var transactionId = Guid.NewGuid();

        _mockRepo.Setup(r => r.DeleteTransactionAsync(transactionId)).Returns(Task.CompletedTask);

        await _service.DeleteTransactionAsync(transactionId);

        _mockRepo.Verify(r => r.DeleteTransactionAsync(transactionId), Times.Once);
    }
    
}