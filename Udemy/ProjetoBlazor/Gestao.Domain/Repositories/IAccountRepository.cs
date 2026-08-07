using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface IAccountRepository
        : IRepository<Account>
    {

        Task<PaginatedList<Account>> GetAllAsync(int companyId, int pageIndex, int pageSize, string? searchAccountName = null);
    }
}
