using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Model.Companies;

namespace Gestao.Domain.Repositories
{
    public interface ICompanyRepository 
        : IRepository<Company>
    {

        Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName = null);
    }
}
