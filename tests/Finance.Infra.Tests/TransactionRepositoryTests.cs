using Finance.Domain.Entities;
using Finance.Domain.Enums;
using Finance.Infra.Persistence;
using Finance.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;


namespace Finance.Infra.Tests;

public class TransactionRepositoryTests
{
    private readonly FinanceDbContext _context;
    private readonly TransactionRepository _repository;

    public TransactionRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<FinanceDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new FinanceDbContext(options);
        _repository = new TransactionRepository(_context);
    }

    [Fact]
    public async Task AddTransactionAsync_ShouldAddTransactionToDatabase()
    {
        var transaction = new Transaction()
        {
            Id = Guid.NewGuid(),
            Description = "Compra de café",
            Amount = 10,
            Date = DateTime.UtcNow,
            Type = TransactionType.Debit
        };

        await _repository.AddTransactionAsync(transaction);

        var transactions = await _repository.GetAllTransactionsAsync();
        transactions.Should().ContainSingle(t => t.Description == "Compra de café");
    }
}