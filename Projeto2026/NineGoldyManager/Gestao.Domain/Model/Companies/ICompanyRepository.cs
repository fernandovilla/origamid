using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;

namespace Gestao.Domain.Model.Companies
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<PaginatedList<Company>> GetAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName = null);
    }
}
