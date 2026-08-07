using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.App.Client.Services
{
    public class FinancialTransactionService(HttpClient httpClient) : IFinancialTransactionRepository
    {
        private readonly string BaseEndPoint = "api/financialtransactions";

        public Task AddAsync(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize, string? searchDesctiption = null)
        {
            var result = await httpClient.GetFromJsonAsync<PaginatedList<FinancialTransaction>>($"{BaseEndPoint}?companyId={companyId}&type={type}&pageIndex={pageIndex}&searchDescription={searchDesctiption}");
            return result!;
        }

        public Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialTransaction>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinancialTransaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FinancialTransaction?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
