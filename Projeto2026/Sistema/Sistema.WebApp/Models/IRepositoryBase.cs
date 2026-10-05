namespace Ninegoldy.Models
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
