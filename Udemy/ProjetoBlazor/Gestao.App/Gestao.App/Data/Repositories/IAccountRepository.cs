using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.App.Data.Repositories
{
    public interface IAccountRepository
        : IRepository<Account>
    {

        Task<PaginatedList<Account>> GetAllAsync(Guid applicationUserId, int companyId, int pageIndex, int pageSize, string? searchAccountName = null);
    }
}
