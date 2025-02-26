using Finance.Domain.Interfaces;
using Finance.Domain.Entities;
using Finance.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly FinanceDbContext _context;
    
    public TransactionRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task AddTransactionAsync(Transaction? transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction?>> GetAllTransactionsAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction?> GetTransactionByIdAsync(Guid id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async  Task DeleteTransactionAsync(Guid id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}