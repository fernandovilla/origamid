using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;

namespace Gestao.App.Client.Services
{
    public class CompanyService : ICompanyRepository
    {
        public Task AddAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
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

        public Task<Company?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
