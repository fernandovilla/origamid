using FluentValidation.TestHelper;
using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.Design;

namespace Gestao.App.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
        //private DbSet<Account> _accounts => _dbFactory.Accounts;

        public AccountRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task AddAsync(Account entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (var db = await _dbFactory.CreateDbContextAsync())
            {
                await db.Accounts.AddAsync(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var category = await GetAsync(id);

            if (category != null)
            {
                using (var db = await _dbFactory.CreateDbContextAsync())
                {
                    db.Accounts.Remove(category);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<IList<Account>> GetAllAsync(int companyId)
        {
            using (var db = await _dbFactory.CreateDbContextAsync())
            {
                var items = await db.Accounts
                    .Where(i => i.CompanyId == companyId)
                    .OrderBy(i => i.Description)
                    .ToListAsync();

                return [.. items];
            }
        }

        public async Task<PaginatedList<Account>> GetAllAsync(int companyId, int pageIndex, int pageSize, string? searchAccountName = null)
        {
            using (var db = await _dbFactory.CreateDbContextAsync())
            {
                var items = await db.Accounts
                    .Where(i => i.CompanyId == companyId)
                    .Where(i => string.IsNullOrEmpty(searchAccountName) || i.Description.Contains(searchAccountName)) // Filter by searchAccountName if provided
                    .OrderByDescending(i => i.Description)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var countCompanies = await db.Accounts
                    .Where(i => i.CompanyId == companyId)
                    .Where(i => string.IsNullOrEmpty(searchAccountName) || i.Description.Contains(searchAccountName)) // Filter by searchAccountName if provided
                    .CountAsync(i => i.CompanyId == companyId);
                var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

                return new PaginatedList<Account>(items, pageIndex, totalPages);
            }
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
            using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Accounts.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Account entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using var db = await _dbFactory.CreateDbContextAsync();
            db.Accounts.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAllAsync()
        {
            using var db = await _dbFactory.CreateDbContextAsync();
            return await db.Accounts.ToListAsync();
        }


    }
}
