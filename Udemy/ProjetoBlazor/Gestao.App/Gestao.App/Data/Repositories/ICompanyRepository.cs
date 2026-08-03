using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.App.Data.Repositories
{
    public interface ICompanyRepository 
        : IRepository<Company>
    {

        Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName = null);
    }
}
