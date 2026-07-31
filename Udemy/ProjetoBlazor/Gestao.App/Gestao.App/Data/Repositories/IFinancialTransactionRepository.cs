using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public interface IFinancialTransactionRepository
        : IRepository<FinancialTransaction>
    {
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, int pageIndex, int pageSize);
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize);
    }
}
