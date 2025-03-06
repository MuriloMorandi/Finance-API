using Finance.Domain.Common;
using Finance.Domain.Enums;

namespace Finance.Domain.Entities;

public class TransactionCategory : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
}