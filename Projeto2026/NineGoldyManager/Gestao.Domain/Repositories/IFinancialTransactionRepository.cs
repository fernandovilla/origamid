using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;

namespace Gestao.Domain.Repositories
{
    public interface IFinancialTransactionRepository
        : IRepository<FinancialTransaction>
    {
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid companyId, int pageIndex, int pageSize);
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize);
        Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize, string? searchDesctiption = null);
        Task<int> GetCountTransactionRepeatGroup(Guid groupId);
        Task<IList<FinancialTransaction>> GetTransactionRepeatGroup(Guid groupId);
        Task DeleteAsync(FinancialTransaction? transaction);
    }
}
