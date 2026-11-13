using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Sessions;
using Gestao.Domain.Model.Customers;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using MudBlazor.Extensions;

namespace Gestao.App.Data.Repositories
{
    public class SessionRepository(ApplicationDbContext DbContext)
        : ISessionRepository
    {
        public async Task<Session> CreateAsync(Session entity)
        {
            await DbContext.Sessions.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var session = await FindByIdAsync(id);

            if (session != null)
                DbContext.Sessions.Remove(session);
        }

        public async Task<Session?> FindByIdAsync(Guid id)
        {
            return await DbContext.Sessions.FindAsync(id);
        }

        public async Task<IQueryable<Session>> GetAsync()
        {
            return DbContext.Sessions.AsQueryable();
        }

        public async Task<IPaginatedList<Session>> ListAsync(Guid companyId, int pageIndex, int pageSize)
        {
            var itens = await DbContext.Sessions    
                    .Where(i => i.Customer!.CompanyId.Equals(companyId))
                    .OrderBy(i => i.CreatedAt)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                    
            var countSessions = await DbContext.Sessions
                .CountAsync(i => i.Customer!.CompanyId.Equals(companyId));

            var totalPages = (int)Math.Ceiling((decimal)countSessions / pageSize);  //.Ceiling arredonda pra cima    

            return new PaginatedList<Session>(itens, pageIndex, totalPages);
        }

        public async Task<IPaginatedList<Session>> ListAsync(Guid companyId, Guid customerId, int pageIndex, int pageSize)
        {
                var itens = await DbContext.Sessions    
                    .Where(i => i.CustumerId.Equals(customerId))
                    .OrderBy(i => i.CreatedAt)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)                    
                    .ToListAsync();
                    
            var countSessions = await DbContext.Sessions
                .CountAsync(i => i.CustumerId.Equals(customerId));

            var totalPages = (int)Math.Ceiling((decimal)countSessions / pageSize);  //.Ceiling arredonda pra cima    

            return new PaginatedList<Session>(itens, pageIndex, totalPages);
        }

        public async Task UpdateAsync(Session entity)
        {
            DbContext.Sessions.Update(entity);
        }
    }
}