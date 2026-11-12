using Gestao.Domain.Model.Companies;
using Gestao.Domain.Model.Customers;
using Gestao.Domain.Model.Sessions;

namespace Gestao.App.Data
{
    public interface IUnitOfWork : IDisposable
    {       
        ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ISessionRepository SessionRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
