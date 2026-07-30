using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class CompanyRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Company> _companies => _db.Companies;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        //TODO - Fazer paginação
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

        public Company Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Company company)
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
