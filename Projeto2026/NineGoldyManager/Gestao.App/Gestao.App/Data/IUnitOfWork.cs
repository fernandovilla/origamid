using Gestao.App.Data.Repositories;
using Gestao.Domain.Model.Companies;
using Gestao.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.App.Data
{
    public interface IUnitOfWork : IDisposable
    {       
        ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }


        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
