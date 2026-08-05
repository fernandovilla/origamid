using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Gestao.App.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Account> _accounts => _db.Accounts;

        public AccountRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Account entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _accounts.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var category = await GetAsync(id);

            if (category != null)
            {
                _accounts.Remove(category);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<Account>> GetAllAsync(int companyId, int pageIndex, int pageSize, string? searchAccountName = null)
        {
            var items = await _accounts
                .Where(i => i.CompanyId == companyId)
                .Where(i => string.IsNullOrEmpty(searchAccountName) || i.Description.Contains(searchAccountName)) // Filter by searchAccountName if provided
                .OrderByDescending(i => i.Description)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var countCompanies = await _accounts
                .Where(i => i.CompanyId == companyId)
                .Where(i => string.IsNullOrEmpty(searchAccountName) || i.Description.Contains(searchAccountName)) // Filter by searchAccountName if provided
                .CountAsync(i => i.CompanyId == companyId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

            return new PaginatedList<Account>(items, pageIndex, totalPages);
        }

        public async Task<PaginatedList<Account>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Account>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Account>> GetAllAsync(Guid applicationUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<Account?> GetAsync(int id)
        {
            return await _accounts.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Account entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _accounts.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _accounts.ToListAsync();
        }

        
    }
}
