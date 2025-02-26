using Finance.Domain.Entities;

namespace Finance.Domain.Interfaces;

public interface ITransactionRepository
{
    Task AddTransactionAsync(Transaction? transaction);
    Task<IEnumerable<Transaction?>> GetAllTransactionsAsync();
    Task<Transaction?> GetTransactionByIdAsync(Guid id);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(Guid id);
}