using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.App.Client.Services
{
    public class FinancialTransactionService(HttpClient httpClient) : IFinancialTransactionRepository
    {
        private readonly string BaseEndPoint = "api/financialtransactions";

        public async Task AddAsync(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }
                
        public async Task DeleteAsync(FinancialTransaction? transaction)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize, string? searchDesctiption = null)
        {
            var result = await httpClient.GetFromJsonAsync<PaginatedList<FinancialTransaction>>($"{BaseEndPoint}?companyId={companyId}&type={type}&pageIndex={pageIndex}&searchDescription={searchDesctiption}");
            return result!;
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid? applicationUserId, Guid companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        
        public async Task<List<FinancialTransaction>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FinancialTransaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<FinancialTransaction?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountTransactionRepeatGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<FinancialTransaction>> GetTransactionRepeatGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<FinancialTransaction>> IRepository<FinancialTransaction>.GetAllAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<FinancialTransaction>> IRepository<FinancialTransaction>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
