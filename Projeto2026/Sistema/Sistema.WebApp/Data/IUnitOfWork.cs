using Ninegoldy.Models.Companies;
using Ninegoldy.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninegoldy.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ICompanyRepository CompanyRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
