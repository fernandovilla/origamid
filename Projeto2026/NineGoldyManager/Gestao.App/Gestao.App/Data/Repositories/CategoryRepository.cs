using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Gestao.App.Data.Repositories
{
    public class CategoryRepository //: ICategoryRepository
    {
        //private readonly IDbContextFactory<ApplicationDbContext> _factory;

        //public CategoryRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        //{
        //    _factory = dbFactory;
        //}

        //public async Task AddAsync(Category entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    using var db = await _factory.CreateDbContextAsync();
        //    await db.Categories.AddAsync(entity);
        //    await db.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(Guid id)
        //{
        //    if (id == null)
        //        throw new ArgumentException("Invalid category ID.", nameof(id));

        //    var category = await GetAsync(id);
        //    if (category == null)
        //        return;

        //    using var db = await _factory.CreateDbContextAsync();

        //    db.Categories.Remove(category);
        //    await db.SaveChangesAsync();
        //}

        //public async Task<IList<Category>> GetAllAsync(Guid companyId)
        //{
        //    using var db = await _factory.CreateDbContextAsync();

        //    var items = await db.Categories
        //        .Where(i => i.CompanyId == companyId)
        //        .OrderBy(i => i.Name)
        //        .ToListAsync();

        //    return [.. items];
        //}

        //public async Task<PaginatedList<Category>> GetAllAsync(Guid companyId, int pageIndex, int pageSize)
        //{
        //    using var db = await _factory.CreateDbContextAsync();

        //    var items = await db.Categories
        //        .Where(i => i.CompanyId == companyId)
        //        .OrderBy(i => i.Name)
        //        .Skip((pageIndex - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    var countCompanies = await db.Categories
        //        .Where(i => i.CompanyId == companyId)
        //        .CountAsync();
        //    var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

        //    return new PaginatedList<Category>(items, pageIndex, totalPages);
        //}

        //public async Task<PaginatedList<Category>> GetAllAsync(Guid? applicationUserId, Guid companyId, int pageIndex, int pageSize)
        //{
        //    using var db = await _factory.CreateDbContextAsync();

        //    var items = await db.Categories
        //        .Where(i => i.CompanyId == companyId)
        //        .OrderBy(i => i.Name)
        //        .Skip((pageIndex - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    var countCompanies = await db.Categories
        //        .Where(i => i.CompanyId == companyId)
        //        .CountAsync();
        //    var totalPages = (int)Math.Ceiling((decimal)countCompanies / pageSize);  //.Ceiling arredonda pra cima

        //    return new PaginatedList<Category>(items, pageIndex, totalPages);
        //}

        //public async Task<Category?> GetAsync(Guid id)
        //{
        //    using var db = await _factory.CreateDbContextAsync();

        //    return await db.Categories.SingleOrDefaultAsync(i => i.Id == id);
        //}

        //public async Task UpdateAsync(Category entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    using var db = await _factory.CreateDbContextAsync();

        //    db.Categories.Update(entity);
        //    await db.SaveChangesAsync();
        //}

        //public async Task<List<Category>> GetAllAsync()
        //{
        //    using var db  = await _factory.CreateDbContextAsync();

        //    return await db.Categories.ToListAsync();
        //}

        //async Task<IQueryable<Category>> IRepository<Category>.GetAllAsync(Guid companyId)
        //{
        //    throw new NotImplementedException();
        //}

        //async Task<IQueryable<Category>> IRepository<Category>.GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
