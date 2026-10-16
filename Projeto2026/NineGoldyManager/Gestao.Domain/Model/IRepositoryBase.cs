using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> GetAsync();
        Task<T?> FindByIdAsync(Guid id);        
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
