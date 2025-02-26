using Finance.Domain.Entities;
using Finance.Domain.Interfaces;

namespace Finance.Application.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task AddTransactionAsync(Transaction? transaction)
    {
        // Adicionar validações aqui
        transaction.Created = DateTime.Now;
        await _transactionRepository.AddTransactionAsync(transaction);
    }
    
    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        // Adicionar validações aqui
        transaction.LastModified = DateTime.Now;
        await _transactionRepository.UpdateTransactionAsync(transaction);
    }

    public async Task<IEnumerable<Transaction?>> GetTransactionsAsync()
    {
        return await _transactionRepository.GetAllTransactionsAsync();
    }
    
    public async Task<Transaction?> GetTransactionByIdAsync(Guid id)
    {
        return await _transactionRepository.GetTransactionByIdAsync(id);
    }
    
    public async Task DeleteTransactionAsync(Guid id)
    {
        await _transactionRepository.DeleteTransactionAsync(id);
    }
    
}