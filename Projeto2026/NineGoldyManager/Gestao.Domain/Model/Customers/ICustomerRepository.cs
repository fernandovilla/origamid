using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IQueryable<Customer>> FindByNameAsync(Guid companyId, string name);
        Task<IPaginatedList<Customer>> ListAsync(Guid companyId, int pageIndex, int pageSize, string? searchCustomerName = null);

    }
}
