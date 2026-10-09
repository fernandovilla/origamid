using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface IAccountRepository
        : IRepository<Account>
    {
        Task<IList<Account>> GetAllAsync(Guid companyId);
        Task<PaginatedList<Account>> GetAllAsync(Guid companyId, int pageIndex, int pageSize, string? searchAccountName = null);
    }
}
