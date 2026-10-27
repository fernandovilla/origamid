using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Customers;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Gestao.App.Data.Repositories
{
    public class CustomerRepository(ApplicationDbContext DbContext)
        : ICustomerRepository
    {
        public async Task<Customer> CreateAsync(Customer entity)
        {
            await DbContext.Customers.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await FindByIdAsync(id);

            if (customer != null)
                DbContext.Customers.Remove(customer);           
        }

        public async Task<Customer?> FindByIdAsync(Guid id)
        {
            return await DbContext.Customers.FindAsync(id);
        }

        public async Task<IQueryable<Customer>> GetAsync()
        {
            return DbContext.Customers.AsQueryable();
        }

        public async Task<IPaginatedList<Customer>> ListAsync(Guid companyId, int pageIndex, int pageSize, string? searchCustomerName = null)
        {
            var itens = await DbContext.Customers
                .Where(i => i.CompanyId.Equals(companyId))
                .Where(i => string.IsNullOrEmpty(searchCustomerName) || i.Name.ToUpper().Contains(searchCustomerName.ToUpper()))
                .OrderBy(i => i.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var countCustomer = await DbContext.Customers
                .Where(i => i.CompanyId.Equals(companyId))
                .Where(i => string.IsNullOrEmpty(searchCustomerName) || i.Name.ToUpper().Contains(searchCustomerName.ToUpper()))
                .CountAsync(i => i.CompanyId.Equals(companyId));

            var totalPages = (int)Math.Ceiling((decimal)countCustomer / pageSize);  //.Ceiling arredonda pra cima    

            return new PaginatedList<Customer>(itens, pageIndex, totalPages);
        }

        public async Task UpdateAsync(Customer entity)
        {
            DbContext.Customers.Update(entity);
        }
    }
}
