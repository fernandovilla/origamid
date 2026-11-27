using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Sessions;
using Gestao.Domain.Model.Customers;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using MudBlazor.Extensions;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var session = await DbContext.Sessions.FindAsync(id);
            
            if (session != null)
                await DbContext.Entry(session).Reference(i => i.Customer).LoadAsync();

            return session;
        }

        public async Task<IQueryable<Session>> GetAsync()
        {        
            var sessions = await DbContext.Sessions.ToListAsync();
            
            sessions.ForEach(async s => await DbContext.Entry(s).Reference(i => i.Customer).LoadAsync());

            return sessions?.AsQueryable();
        }

        public async Task<IPaginatedList<Session>> ListAsync(Guid companyId, int pageIndex, int pageSize)
             => await ListAsync(companyId, null, pageIndex, pageSize, false, string.Empty);            

        public async Task<IPaginatedList<Session>> ListAsync(Guid companyId, Guid customerId, int pageIndex, int pageSize)
            => await ListAsync(companyId, customerId, pageIndex, pageSize, false, string.Empty);            

        public async Task<IPaginatedList<Session>> ListAsync(Guid? companyId, Guid? customerId, int pageIndex, int pageSize, bool include)
            => await ListAsync(companyId, customerId, pageIndex, pageSize, include, string.Empty);            

        public async Task<IPaginatedList<Session>> ListAsync(Guid? companyId, Guid? customerId, int pageIndex, int pageSize, bool include, string searchText)
        {
            var sessions = await DbContext.Sessions                    
                .Where(i => companyId != null  ? i.Customer!.CompanyId.Equals(companyId): true)
                .Where(i => customerId != null ? i.CustomerId.Equals(customerId) : true)                
                .Where(i => !string.IsNullOrEmpty(searchText) ? i.Customer!.Name.Contains(searchText) : true)
                .Include(i => include ? i.Customer : null)
                .OrderByDescending(i => i.CreatedAt)
                .OrderByDescending(i => i.UpdatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)                                    
                .ToListAsync();

            var countSessions = await DbContext.Sessions
                .Where(i => companyId != null  ? i.Customer!.CompanyId.Equals(companyId): true)
                .Where(i => customerId != null ? i.CustomerId.Equals(customerId) : true)                
                .Where(i => !string.IsNullOrEmpty(searchText) ? i.Customer!.Name.Contains(searchText) : true)
                .CountAsync();

            var totalPages = (int)Math.Ceiling((decimal)countSessions / pageSize);  //.Ceiling arredonda pra cima    

            return new PaginatedList<Session>(sessions, pageIndex, totalPages);
        }

        public async Task UpdateAsync(Session entity)
        {
            DbContext.Sessions.Update(entity);
        }
    }
}