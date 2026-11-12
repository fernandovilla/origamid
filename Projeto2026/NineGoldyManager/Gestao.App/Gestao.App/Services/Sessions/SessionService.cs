using Gestao.App.Data;
using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Model.Sessions;

namespace Gestao.App.Services.Sessions
{
    public class SessionService(IUnitOfWorkFactory UnitOfWorkFactory) : ISessionService
    {
        public async Task<Session> CreateAsync(Session session)
        {
            using var unit = UnitOfWorkFactory.Create();

            await unit.SessionRepository.CreateAsync(session);

            await unit.SaveChangesAsync();

            return session;
        }

        public async Task DeleteAsync(Guid id)
        {
            using var unit = UnitOfWorkFactory.Create();

            await unit.SessionRepository.DeleteAsync(id);

            await unit.SaveChangesAsync();
        }

        public async Task<Session> FindByIdAsync(Guid id)
        {
            using var unit = UnitOfWorkFactory.Create();
            return await unit.SessionRepository.FindByIdAsync(id);
        }

        public async Task<IPaginatedList<Session>> ListAsync(Guid companyId, int pageIndex, int pageSize)
        {
            using var unit = UnitOfWorkFactory.Create();
            return await unit.SessionRepository.ListAsync(companyId, pageIndex, pageSize);
        }

        public async Task<IPaginatedList<Session>> ListAsync(Guid companyId, Guid customerId, int pageIndex, int pageSize)
        {
            using var unit = UnitOfWorkFactory.Create();
            return await unit.SessionRepository.ListAsync(companyId, customerId, pageIndex, pageSize);
        }

        public async Task UpdateAsync(Session session)
        {
            using var unit = UnitOfWorkFactory.Create();

            await unit.SessionRepository.UpdateAsync(session);

            await unit.SaveChangesAsync();
        }
    {
        
    }
}
