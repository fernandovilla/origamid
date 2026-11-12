using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Sessions;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using MudBlazor.Extensions;

namespace Gestao.App.Data.Repositories
{
    public class SessionRepository(ApplicationDbContext DbContext)
        : ISessionRepository
    {
        public Task<Session> CreateAsync(Session entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Session?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Session>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IPaginatedList<Session>> ListAsync(Guid companyId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IPaginatedList<Session>> ListAsync(Guid companyId, Guid customerId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Session entity)
        {
            throw new NotImplementedException();
        }
    }
}