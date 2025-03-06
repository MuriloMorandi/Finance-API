using Finance.Application.DTOs;
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
        if (transaction.Amount <= 0)
        {
            throw new Exception("Amount must be greater than zero");
        }

        if (transaction.Description.Trim() == String.Empty)
        {
            throw new Exception("Description is required");
        }
        
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
    
    public async Task<TransactionDTO?> GetTransactionByIdAsync(Guid id)
    {
        var  ret  = await _transactionRepository.GetByIdAsync(id);
        if (ret != null) return new TransactionDTO(ret);;

        return null;
    }
    
    public async Task DeleteTransactionAsync(Guid id)
    {
        await _transactionRepository.DeleteAsync(id);
    }
    
}