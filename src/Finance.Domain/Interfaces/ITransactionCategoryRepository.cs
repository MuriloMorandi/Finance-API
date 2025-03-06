using Finance.Domain.Entities;

namespace Finance.Domain.Interfaces;

public interface ITransactionCategoryRepository
{
    Task AddTransactionCategoryAsync(TransactionCategory? TransactionCategory);
    Task<IEnumerable<TransactionCategory?>> GetAllTransactionCategorysAsync();
    Task<TransactionCategory?> GetTransactionCategoryByIdAsync(Guid id);
    Task UpdateTransactionCategoryAsync(TransactionCategory TransactionCategory);
    Task DeleteTransactionCategoryAsync(Guid id);
}