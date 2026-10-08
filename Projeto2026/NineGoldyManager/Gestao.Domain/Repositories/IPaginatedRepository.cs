using Gestao.Domain.Libraries.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Repositories
{
    public class IPaginatedRepository<T> where T : class
    {
        Task<PaginatedList<T>> GetAllAsync(Guid companyId, int pageIndex, int pageSize);
    }
}
