using Ninegoldy.Models.Companies;
using Ninegoldy.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninegoldy.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICompanyRepository CompanyRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
