using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.App.Client.Services
{
    public class AccountService(HttpClient httpClient) 
        : IAccountRepository
    {
        private readonly string BaseEndPoint = "api/accounts";

        public Task AddAsync(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Account>> GetAllAsync(int companyId, int pageIndex, int pageSize, string? searchAccountName = null)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Account>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Account>> GetAllAsync(int companyId)
        {
            var result = await httpClient.GetFromJsonAsync<IList<Account>>($"{BaseEndPoint}?companyId={companyId}");

            return result!;
        }

        public async Task<PaginatedList<Account>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            var result = await httpClient.GetFromJsonAsync<PaginatedList<Account>>($"{BaseEndPoint}?applicationUserId={applicationUserId}&pageIndex={pageIndex}");

            return result!;
        }

        public Task<List<Account>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
