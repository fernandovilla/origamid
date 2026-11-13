using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Model.Customers
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IQueryable<Customer>> FindByNameAsync(Guid? companyId, string name);
        Task<IPaginatedList<Customer>> ListAsync(Guid? companyId, int pageIndex, int pageSize, string? searchCustomerName = null);

    }
}
