using Finance.Domain.Enums;

namespace Finance.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
}