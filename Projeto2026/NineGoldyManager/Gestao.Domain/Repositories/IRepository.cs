using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {                
        Task<T?> GetAsync(Guid id);
        Task<IQueryable<T>> GetAsync();
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
