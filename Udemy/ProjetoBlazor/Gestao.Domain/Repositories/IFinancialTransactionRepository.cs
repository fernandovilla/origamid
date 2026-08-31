using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface IFinancialTransactionRepository
        : IRepository<FinancialTransaction>
    {
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, int pageIndex, int pageSize);
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize);
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize, string? searchDesctiption = null);
        Task<int> GetCountTransactionRepeatGroup(int groupId);
        Task<IList<FinancialTransaction>> GetTransactionRepeatGroup(int groupId);
        Task DeleteAsync(FinancialTransaction? transaction);
    }
}
