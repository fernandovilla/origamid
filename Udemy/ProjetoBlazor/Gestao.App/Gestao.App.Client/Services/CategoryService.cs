using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.App.Client.Services
{
    public class CategoryService(HttpClient httpClient) : ICategoryRepository
    {
        private readonly string BaseEndPoint = "api/categories";

        public Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Category>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            var result = await httpClient.GetFromJsonAsync<PaginatedList<Category>>($"{BaseEndPoint}?companyId={companyId}&pageIndex={pageIndex}");
            return result!;
        }

        public Task<PaginatedList<Category>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Category>> GetAllAsync(int companyId, int pageIndex, int pageSize)
        {
            return await GetAllAsync(null, companyId, pageIndex, pageSize);
        }

        public Task<Category?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
