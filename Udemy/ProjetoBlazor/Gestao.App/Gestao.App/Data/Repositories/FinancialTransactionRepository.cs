using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class FinancialTransactionRepository  : IFinancialTransactionRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<FinancialTransaction> _financialTransactions => _db.FinancialTransactions;

        public FinancialTransactionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(FinancialTransaction entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _financialTransactions.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var category = await GetAsync(id);

            if (category != null)
            {
                _financialTransactions.Remove(category);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            return await GetAllAsync(companyId, pageIndex, pageSize);
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, int pageIndex, int pageSize)
        {
            var items = (await GetAllAsync()).Where(i => i.CompanyId == companyId)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            var countCompanies = await _financialTransactions.CountAsync(i => i.CompanyId == companyId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  

            return new PaginatedList<FinancialTransaction>(items, pageIndex, totalPages);
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize)
        {
            var items = (await GetAllAsync()).Where(i => i.CompanyId == companyId && i.FinancialTransactionType == type)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            var countCompanies = await _financialTransactions.CountAsync(i => i.CompanyId == companyId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  

            return new PaginatedList<FinancialTransaction>(items, pageIndex, totalPages);
        }

        public async Task<List<FinancialTransaction>> GetAllAsync(Guid applicationUserId)
        {
            return await GetAllAsync();
        }

        public async Task<List<FinancialTransaction>> GetAllAsync()
        {
            return await _financialTransactions.ToListAsync();
        }

        public async Task<FinancialTransaction?> GetAsync(int id)
        {
            return await _financialTransactions
                .Include(i => i.Documents)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(FinancialTransaction entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _financialTransactions.Update(entity);
            await _db.SaveChangesAsync();
        }

        
    }
}
