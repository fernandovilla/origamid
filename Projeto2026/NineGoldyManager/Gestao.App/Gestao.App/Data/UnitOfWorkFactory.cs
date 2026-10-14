using Gestao.Domain.Model.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data
{
    public sealed class UnitOfWorkFactory(IDbContextFactory<ApplicationDbContext> DBContextFactory, UserManager<ApplicationUser> UserManager) 
        : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(DBContextFactory.CreateDbContext(), UserManager);
        }
    }
}
