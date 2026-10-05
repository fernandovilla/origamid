using System.Linq.Expressions;

namespace Ninegoldy.Models
{
    public interface IRepositoryBase<T>
    {        
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
