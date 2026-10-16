using Gestao.App.Data.Repositories;
using Gestao.Domain.Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.App.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ICompanyRepository CompanyRepository { get; }


        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
