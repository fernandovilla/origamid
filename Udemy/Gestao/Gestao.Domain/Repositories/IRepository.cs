using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<PaginatedList<T>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize);
        Task<PaginatedList<T>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize);
        Task<List<T>> GetAllAsync(Guid applicationUserId);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
