using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        
        public DocumentRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _factory = dbFactory;
        }

        public async Task AddAsync(Document entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using var db = await _factory.CreateDbContextAsync();

            await db.Documents.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var attachmentDocument = await GetAsync(id);

            if (attachmentDocument != null)
            {
                using var db = await _factory.CreateDbContextAsync();

                db.Documents.Remove(attachmentDocument);
                await db.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<Document>> GetAllAsync(Guid? applicationUserId, int companyId, int pageIndex, int pageSize)
        {
            return await GetAllAsync(0, pageIndex, pageSize);
        }

        public async Task<PaginatedList<Document>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            return await GetAllAsync(0, pageIndex, pageSize);
        }

        public async Task<List<Document>> GetAllAsync(Guid applicationUserId)
        {
            return (await GetAllAsync(0, 0, 0)).Items;
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return (await GetAllAsync(0, 0, 0)).Items;
        }

        public async Task<PaginatedList<Document>> GetAllAsync(int financialTransactionId, int pageIndex, int pageSize)
        {
            return await GetAllAsync(financialTransactionId, pageIndex, pageSize, null);
        }

        public async Task<PaginatedList<Document>> GetAllAsync(int financialTransactionId, int pageIndex, int pageSize, string? searchDescription = null)
        {
            if (financialTransactionId <= 0)
                throw new ArgumentException("Invalid financial transaction ID.", nameof(financialTransactionId));

            using var db = await _factory.CreateDbContextAsync();

            var items = await db.Documents
                .Where(i => i.FinancialTransactionId == financialTransactionId)
                .Where(i => string.IsNullOrEmpty(searchDescription) || i.Path.Contains(searchDescription))
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var countCompanies = await db.Documents
                .Where(i => i.FinancialTransactionId == financialTransactionId)
                .Where(i => string.IsNullOrEmpty(searchDescription) || i.Path.Contains(searchDescription))
                .CountAsync(i => i.FinancialTransactionId == financialTransactionId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);

            return new PaginatedList<Document>(items, pageIndex, totalPages);
        }

        public async Task<Document?> GetAsync(int id)
        {
            using var db = await _factory.CreateDbContextAsync();

            return await db.Documents.SingleOrDefaultAsync(i => i.ID == id);
        }

        public async Task UpdateAsync(Document entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using var db = await _factory.CreateDbContextAsync();

            db.Documents.Update(entity);
            await db.SaveChangesAsync();
        }        
    }
}
