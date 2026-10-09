using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface ICategoryRepository
        : IRepository<Category>
    {
        Task<IList<Category>> GetAllAsync(Guid companyId);
        Task<PaginatedList<Category>> GetAllAsync(Guid companyId, int pageIndex, int pageSize);
    }
}
