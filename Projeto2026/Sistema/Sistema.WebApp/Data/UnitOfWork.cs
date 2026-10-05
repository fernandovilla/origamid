using Microsoft.EntityFrameworkCore;
using Ninegoldy.Models.Companies;
using Ninegoldy.Models.Users;

namespace Ninegoldy.Data
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IUserRepository? _userRepository;
        private ICompanyRepository? _companyRepository;

        public IUserRepository UserRepository => _userRepository ?? (new UserRepository(context));
        public ICompanyRepository CompanyRepository => _companyRepository ?? (new CompanyRepository(context));
    }


    partial class UnitOfWork 
    {       
        private readonly ApplicationDbContext context;

        public UnitOfWork(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            context = dbContextFactory.CreateDbContext();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
