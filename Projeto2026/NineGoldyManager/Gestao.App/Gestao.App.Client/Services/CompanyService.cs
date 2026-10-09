using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Model.Companies;
using Gestao.Domain.Repositories;

namespace Gestao.App.Client.Services
{
    public class CompanyService : ICompanyRepository
    {
        public async Task AddAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName = null)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Company>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        
        public async Task<Company?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        Task<PaginatedList<Company>> ICompanyRepository.GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<Company>> IRepository<Company>.GetAllAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<Company>> IRepository<Company>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
