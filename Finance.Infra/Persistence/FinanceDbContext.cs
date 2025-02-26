using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Persistence;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }
    
    public DbSet<Transaction?> Transactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
        modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasColumnType("decimal(18,2)");
    }
    
}