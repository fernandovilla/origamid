using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public CompanyRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _factory = dbFactory;
        }

        public async Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize, string? searchCompanyName = null)
        {
            // LINQ:
            //  .Skip(x)       //pula x registros = ((PageIndex - 1) * PageSize)
            //  .Take(n)      //pega n registros = PageSize = 15

            using var db = await _factory.CreateDbContextAsync();

            var items = await db.Companies
                .Where(i => i.UserId == applicationUserId)
                .Where(i => string.IsNullOrEmpty(searchCompanyName) || i.TradeName.Contains(searchCompanyName) || i.LegalName.Contains(searchCompanyName))
                .OrderBy(i => i.TradeName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var countCompanies = await db.Companies
                .Where(i => i.UserId == applicationUserId)
                .Where(i => string.IsNullOrEmpty(searchCompanyName) || i.TradeName.Contains(searchCompanyName) || i.LegalName.Contains(searchCompanyName))
                .CountAsync(i => i.UserId == applicationUserId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

            return new PaginatedList<Company>(items, pageIndex, totalPages);
        }

        public async Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            return await GetAllAsync(applicationUserId, pageIndex, pageSize, null);
        }

        public async Task<PaginatedList<Company>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<Company?> GetAsync(int id)
        {
            using var db = await _factory.CreateDbContextAsync();

            return await db.Companies.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            using var db = await _factory.CreateDbContextAsync();

            await db.Companies.AddAsync(company);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            using var db = await _factory.CreateDbContextAsync();

            db.Companies.Update(company);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid company ID.", nameof(id));

            var company = await GetAsync(id);

            if (company == null)
                return;

            using var db = await _factory.CreateDbContextAsync();

            db.Companies.Remove(company);
            await db.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            using var db = await _factory.CreateDbContextAsync();

            return await db.Companies.ToListAsync();
        }
    }
}
