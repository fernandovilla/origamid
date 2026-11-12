using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Sessions;

namespace Gestao.App.Services.Sessions
{
    public interface ISessionService
    {
        Task<Session> CreateAsync(Session session);
        Task<Session> FindByIdAsync(Guid id);        
        Task UpdateAsync(Session session);
        Task DeleteAsync(Guid id);
        Task<IPaginatedList<Session>> ListAsync(Guid companyId, int pageIndex, int pageSize);
        Task<IPaginatedList<Session>> ListAsync(Guid companyId, Guid customerId, int pageIndex, int pageSize);
    }
}
