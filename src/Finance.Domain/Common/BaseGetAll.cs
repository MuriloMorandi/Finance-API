namespace Finance.Domain.Interfaces.Common;

public class BaseGetAll<T> where T : class
{
    public IEnumerable<T> data { get; set; }
    public int totalData { get; set; }
}