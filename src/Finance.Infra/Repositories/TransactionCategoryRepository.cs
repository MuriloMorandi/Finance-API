using Finance.Domain.Interfaces;
using Finance.Domain.Entities;
using Finance.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Repositories;

public class TransactionCategoryRepository : ITransactionCategoryRepository
{
    private readonly FinanceDbContext _context;
    
    public TransactionCategoryRepository(FinanceDbContext context)
    {
        _context = context;
    }


    public async Task  AddTransactionCategoryAsync(TransactionCategory? transactionCategory)
    {
        _context.TransactionCategories.Add(transactionCategory);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TransactionCategory?>> GetAllTransactionCategorysAsync()
    {
        return await _context.TransactionCategories.ToListAsync();
    }

    public async Task<TransactionCategory?> GetTransactionCategoryByIdAsync(Guid id)
    {
        return await _context.TransactionCategories.FindAsync(id);
    }

    public async Task UpdateTransactionCategoryAsync(TransactionCategory transactionCategory)
    {
        _context.TransactionCategories.Update(transactionCategory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactionCategoryAsync(Guid id)
    {
        var transactionCategory = await _context.TransactionCategories.FindAsync(id);
        if (transactionCategory != null)
        {
            _context.TransactionCategories.Remove(transactionCategory);
            await _context.SaveChangesAsync();
        }
    }
}