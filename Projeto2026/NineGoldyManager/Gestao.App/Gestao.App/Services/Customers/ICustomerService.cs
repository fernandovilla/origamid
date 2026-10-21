using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Customers;

namespace Gestao.App.Services.Customers
{
    public interface ICustomerService
    {
        Task<Customer> CreateAscyn(Customer customer);
        Task<Customer> FindByIdAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
        Task<IPaginatedList<Customer>> ListAsync(Guid companyId, int pageIndex, int pageSize, string? searchCustomerName);
    }
}
