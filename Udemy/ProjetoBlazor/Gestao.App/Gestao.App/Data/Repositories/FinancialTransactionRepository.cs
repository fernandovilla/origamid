using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
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
                throw new ArgumentException("Invalid transaction ID.", nameof(id));

            var transaction = await GetAsync(id);

            await DeleteAsync(transaction);
        }

        public async Task DeleteAsync(FinancialTransaction? transaction)
        {
            if (transaction != null)
            {
                _financialTransactions.Remove(transaction);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
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
                .OrderBy(i => i.ReferenceDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var countCompanies = await _financialTransactions.CountAsync(i => i.CompanyId == companyId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);

            return new PaginatedList<FinancialTransaction>(items, pageIndex, totalPages);
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize)
        {
            return await GetAllAsync(companyId, type, pageIndex, pageSize, null);
        }

        public async Task<PaginatedList<FinancialTransaction>> GetAllAsync(int companyId, FinancialTransactionTypeEnum type, int pageIndex, int pageSize, string? searchDesctiption = null)
        {
            var items = await _financialTransactions
                .Include(i => i.Account)
                .Include(i => i.Category)
                .Include(i => i.Documents)
                .Where(i => i.CompanyId == companyId && i.FinancialTransactionType == type)
                .Where(i => string.IsNullOrEmpty(searchDesctiption) || i.Description.Contains(searchDesctiption)) // Filter by searchDescription if provided
                .OrderBy(i => i.ReferenceDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var countCompanies = await _financialTransactions
                .Where(i => i.CompanyId == companyId && i.FinancialTransactionType == type)
                .Where(i => string.IsNullOrEmpty(searchDesctiption) || i.Description.Contains(searchDesctiption))
                .CountAsync(i => i.CompanyId == companyId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);

            return new PaginatedList<FinancialTransaction>(items, pageIndex, totalPages);
        }

        public async Task<List<FinancialTransaction>> GetAllAsync(Guid applicationUserId)
        {
            return GetAllFinancialTransaction(null, null).ToList();

        }

        public async Task<List<FinancialTransaction>> GetAllAsync()
        {
            return GetAllFinancialTransaction(null, null).ToList();
        }

        private IEnumerable<FinancialTransaction> GetAllFinancialTransaction(int? companyId, FinancialTransactionTypeEnum? type)
        {
            return _financialTransactions
                .Where(i => companyId != null ? i.CompanyId == companyId : false)
                .Where(i => type != null ? i.FinancialTransactionType != type : false)
                .Include(i => i.Account)
                .Include(i => i.Category)
                .Include(i => i.Documents);
        }

        public async Task<FinancialTransaction?> GetAsync(int id)
        {
            return await _financialTransactions
                .Include(i => i.Category)
                .Include(i => i.Account)
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

        public async Task<int> GetCountTransactionRepeatGroup(int groupId)
        {
            return await _financialTransactions
                .Where(i => i.RepeatGroup == groupId)
                .OrderBy(i => i.Id)
                .CountAsync();
        }

        public async Task<IList<FinancialTransaction>> GetTransactionRepeatGroup(int groupId)
        {
            return await _financialTransactions
                .Where(i => i.RepeatGroup == groupId)
                .OrderBy(i => i.Id)
                .ToListAsync();
        }


    }
}
