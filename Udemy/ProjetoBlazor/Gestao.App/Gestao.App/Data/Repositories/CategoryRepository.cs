using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gestao.App.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private DbSet<Category> _categories => _db.Categories;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;   
        }

        public async Task AddAsync(Category entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _categories.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var category = await GetAsync(id);

            if (category != null)
            {
                _categories.Remove(category);
                await _db.SaveChangesAsync();
            }
        }

        public Task<PaginatedList<Category>> GetAllAsync(Guid applicationUserId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<Category>> GetAllAsync(Guid applicationUserId,int companyId, int pageIndex, int pageSize)
        {
            var items = await _categories.Where(i => i.UserId == applicationUserId && i.CompanyId == companyId)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var countCompanies = await _categories.CountAsync(i => i.UserId == applicationUserId);
            var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

            return new PaginatedList<Category>(items, pageIndex, totalPages);
        }

        public async Task<List<Category>> GetAllAsync(Guid applicationUserId)
        {
            return await _categories.Where(i => i.UserId == applicationUserId).ToListAsync();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await _categories.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _categories.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categories.ToListAsync();
        }
    }
}
