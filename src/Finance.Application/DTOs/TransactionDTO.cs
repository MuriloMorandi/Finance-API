using Finance.Domain.Entities;
using Finance.Domain.Enums;

namespace Finance.Application.DTOs;

public class TransactionDTO
{
    public Guid? id { get; set; }
    public string description { get; set; }
    public decimal amount { get; set; }
    public DateTime date { get; set; }
    public string type { get; set; }
    
    public TransactionDTO(Transaction transaction)
    {
        id = transaction.Id;
        description = transaction.Description;
        amount = transaction.Amount;
        date = transaction.Date;
        type = transaction.Type.ToString();
    }

    public TransactionDTO(string description, decimal amount, DateTime date, string type)
    {
        this.description = description;
        this.amount = amount;
        this.date = date;
        this.type = type;
    }
}