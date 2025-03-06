using Finance.Domain.Entities;
using Finance.Domain.Interfaces;

namespace Finance.Application.Services;

public class TransactionCategoryService
{
    private readonly ITransactionCategoryRepository _transactionCategoryRepository;

    public TransactionCategoryService(ITransactionCategoryRepository transactionCategoryRepository)
    {
        _transactionCategoryRepository = transactionCategoryRepository;
    }

    public async Task AddTransactionAsync(TransactionCategory? transactionCategory)
    {
        // Adicionar validações aqui
        transactionCategory.Created = DateTime.Now;
        await _transactionCategoryRepository.AddTransactionCategoryAsync(transactionCategory);
    }
    
    public async Task UpdateTransactionAsync(TransactionCategory transactionCategory)
    {
        // Adicionar validações aqui
        transactionCategory.LastModified = DateTime.Now;
        await _transactionCategoryRepository.UpdateTransactionCategoryAsync(transactionCategory);
    }

    public async Task<IEnumerable<TransactionCategory?>> GetTransactionsAsync()
    {
        return await _transactionCategoryRepository.GetAllTransactionCategorysAsync();
    }
    
    public async Task<TransactionCategory?> GetTransactionByIdAsync(Guid id)
    {
        return await _transactionCategoryRepository.GetTransactionCategoryByIdAsync(id);
    }
    
    public async Task DeleteTransactionAsync(Guid id)
    {
        await _transactionCategoryRepository.DeleteTransactionCategoryAsync(id);
    }
    
}