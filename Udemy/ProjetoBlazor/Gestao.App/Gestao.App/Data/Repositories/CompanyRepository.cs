using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Company> _companies => _db.Companies;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            // LINQ:
            //  .Skip(x)       //pula x registros = ((PageIndex - 1) * PageSize)
            //  .Take(n)      //pega n registros = PageSize = 15

            var items = await _companies.Where(i => i.UserId == applicationUserId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var countCompanies = await _companies.CountAsync(i => i.UserId == applicationUserId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

            return new PaginatedList<Company>(items, pageIndex, totalPages);
        }

        public async Task<PaginatedList<Company>> GetAllAsync(Guid applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<Company?> GetAsync(int id)
        {
            return await _companies.SingleOrDefaultAsync(i => i.Id == id);   
        }

        public async Task AddAsync(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));   

            await _companies.AddAsync(company);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            _companies.Update(company);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid company ID.", nameof(id));

            var company = await GetAsync(id);

            if (company != null)
            {
                _companies.Remove(company);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companies.ToListAsync();
        }
    }
}
