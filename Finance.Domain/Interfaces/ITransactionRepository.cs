using Finance.Domain.Entities;

namespace Finance.Domain.Interfaces;

public interface ITransactionRepository
{
    Task AddTransactionAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
}