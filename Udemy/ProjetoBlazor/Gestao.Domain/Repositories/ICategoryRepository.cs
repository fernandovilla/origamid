using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface ICategoryRepository
        : IRepository<Category>
    {
        Task<PaginatedList<Category>> GetAllAsync(int companyId, int pageIndex, int pageSize);
    }
}
