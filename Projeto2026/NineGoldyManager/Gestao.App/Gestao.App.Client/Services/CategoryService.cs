using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.App.Client.Services
{
    public class CategoryService(HttpClient httpClient) : ICategoryRepository
    {
        private readonly string BaseEndPoint = "api/categories";

        public async Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Category>> GetAllAsync(int companyId)
        {
            var result = await httpClient.GetFromJsonAsync<IList<Category>>($"{BaseEndPoint}?companyId={companyId}");
            return result!;
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

        
        public async Task<Category?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        async Task<IQueryable<Category>> IRepository<Category>.GetAllAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        async Task<IQueryable<Category>> IRepository<Category>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        async Task<IList<Category>> ICategoryRepository.GetAllAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }
    }
}
