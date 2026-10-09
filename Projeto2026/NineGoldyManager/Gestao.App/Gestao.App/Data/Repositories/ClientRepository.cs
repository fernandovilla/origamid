using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class ClientRepository(IDbContextFactory<ApplicationDbContext> _dbContextFactory) : IClientRepository
    {
        public Task AddAsync(Domain.Model.Clients.Client entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Domain.Model.Clients.Client>> GetAllAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Domain.Model.Clients.Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Model.Clients.Client?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Model.Clients.Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
