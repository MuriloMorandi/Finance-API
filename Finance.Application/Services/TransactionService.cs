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

    public async Task AddTransactionAsync(Transaction transaction)
    {
        // Você pode adicionar validações aqui
        await _transactionRepository.AddTransactionAsync(transaction);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
    {
        return await _transactionRepository.GetAllTransactionsAsync();
    }
}