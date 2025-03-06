using Finance.Domain.Interfaces.Common;

namespace Finance.Domain.Interfaces;

public interface IBaseRespository<T> where T : class
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<BaseGetAll<T>> GetAllAsync(); 
}
