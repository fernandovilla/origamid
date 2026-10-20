using Gestao.Domain.Model.Customers;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Gestao.App.Data.Repositories
{
    public class CustomerRepository(IDbContextFactory<ApplicationDbContext> DbContextFactory) 
        : ICustomerRepository
    {
        public async Task<Customer> CreateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Customer>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
