using Gestao.App.Data;
using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Customers;

namespace Gestao.App.Services.Customers
{
    public class CustomerService(IUnitOfWorkFactory UnitOfWorkFactory) : ICustomerService
    {
        public async Task<Customer> CreateAscyn(Customer customer)
        {
            using var unit = UnitOfWorkFactory.Create();

            await unit.CustomerRepository.CreateAsync(customer);

            await unit.SaveChangesAsync();

            return customer;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> FindByIdAsync(Guid id)
        {
            using var unit = UnitOfWorkFactory.Create();
            return await unit.CustomerRepository.FindByIdAsync(id);
        }

        public async Task<IPaginatedList<Customer>> ListAsync(Guid companyId, int pageIndex, int pageSize, string? searchCustomerName)
        {
            using var unit = UnitOfWorkFactory.Create();
            return await unit.CustomerRepository.ListAsync(companyId, pageIndex, pageSize, searchCustomerName);
        }

        public async Task UpdateAsync(Customer customer)
        {
            using var unit = UnitOfWorkFactory.Create();

            await unit.CustomerRepository.UpdateAsync(customer);

            await unit.SaveChangesAsync();
        }
    }
}
