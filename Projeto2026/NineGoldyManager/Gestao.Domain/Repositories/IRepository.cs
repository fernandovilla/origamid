using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {        
        Task<IQueryable<T>> GetAllAsync(Guid companyId);
        Task<IQueryable<T>> GetAllAsync();
        Task<T?> GetAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
