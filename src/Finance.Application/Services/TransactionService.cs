using Finance.Domain.Entities;
using Finance.Domain.Interfaces;
using Finance.Domain.Interfaces.Common;

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
        await _transactionRepository.AddAsync(transaction);
    }
    
    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        // Adicionar validações aqui
        transaction.LastModified = DateTime.Now;
        await _transactionRepository.UpdateAsync(transaction);
    }

    public async Task<BaseGetAll<Transaction>> GetTransactionsAsync()
    {
        return await _transactionRepository.GetAllAsync();
    }
    
    public async Task<Transaction?> GetTransactionByIdAsync(Guid id)
    {
        return await _transactionRepository.GetByIdAsync(id);
    }
    
    public async Task DeleteTransactionAsync(Guid id)
    {
        await _transactionRepository.DeleteAsync(id);
    }
    
}