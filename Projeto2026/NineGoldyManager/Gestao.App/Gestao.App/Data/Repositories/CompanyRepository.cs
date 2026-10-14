using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Model.Companies;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class CompanyRepository(ApplicationDbContext _dbContext) : ICompanyRepository
    {
        public Task<Company> CreateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Company>> GetAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName = null)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Company>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
