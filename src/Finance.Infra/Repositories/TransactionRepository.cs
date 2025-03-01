using Finance.Domain.Interfaces;
using Finance.Domain.Entities;
using Finance.Domain.Interfaces.Common;
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

    public async Task AddAsync(Transaction? transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<BaseGetAll<Transaction>> GetAllAsync()
    {
        var ret = new BaseGetAll<Transaction>();
        ret.data = await _context.Transactions.ToListAsync();
        ret.totalData = await _context.Transactions.CountAsync();
        
        return ret;
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async  Task DeleteAsync(Guid id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}