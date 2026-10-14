using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Gestao.App.Data.Repositories
{
    public class ClientRepository(IDbContextFactory<ApplicationDbContext> _dbContextFactory) //: IClientRepository
    {
        public Task<Gestao.Domain.Model.Clients.Cliente> AddAsync(Domain.Model.Clients.Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Domain.Model.Clients.Cliente>> GetAllAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Domain.Model.Clients.Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Model.Clients.Cliente?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Model.Clients.Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
