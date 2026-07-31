using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Gestao.App.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Document> _documents => _db.Documents;

        public DocumentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Document entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _documents.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var attachmentDocument = await GetAsync(id);

            if (attachmentDocument != null)
            {
                _documents.Remove(attachmentDocument);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<Document>> GetAllAsync(Guid applicationUserId, int companyId, int pageIndex, int pageSize)
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
            if (financialTransactionId <= 0)
                throw new ArgumentException("Invalid financial transaction ID.", nameof(financialTransactionId));

            var items = await _documents.Where(i => i.FinancialTrsnsactionId == financialTransactionId)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var countCompanies = await _documents.CountAsync(i => i.FinancialTrsnsactionId == financialTransactionId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);

            return new PaginatedList<Document>(items, pageIndex, totalPages);
        }

        public async Task<Document?> GetAsync(int id)
        {
            return await _documents.SingleOrDefaultAsync(i => i.ID == id);
        }

        public async Task UpdateAsync(Document entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _documents.Update(entity);
            await _db.SaveChangesAsync();
        }

        
    }
}
