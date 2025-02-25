using Finance.Domain.Interfaces;
using Finance.Domain.Entities;

namespace Finance.Infra.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly List<Transaction> _transactions = new();

    public async Task AddTransactionAsync(Transaction transaction)
    {
        _transactions.Add(transaction);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
        return await Task.FromResult(_transactions);
    }
}