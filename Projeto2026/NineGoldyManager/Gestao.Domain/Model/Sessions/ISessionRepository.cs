using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Model.Sessions
{
    public interface ISessionRepository : IRepositoryBase<Session>
    {    
        Task<IPaginatedList<Session>> ListAsync(Guid companyId, int pageIndex, int pageSize);
        Task<IPaginatedList<Session>> ListAsync(Guid companyId, Guid customerId, int pageIndex, int pageSize);
    }
}
