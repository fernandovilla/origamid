using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Gestao.App.Data.Repositories;
using Gestao.Domain.Repositories;
//using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using Gestao.Domain.Model.Users;

namespace Gestao.App.Data
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IApplicationUserRepository? _userRepository;
        private ICompanyRepository? _companyRepository;

        public IApplicationUserRepository UserRepository => _userRepository ?? (new ApplicationUserRepository(_userManager));
        public ICompanyRepository CompanyRepository => _companyRepository ?? (new CompanyRepository(_context));
    }


    partial class UnitOfWork
    {
        //[Inject]
        //private IDbContextFactory<ApplicationDbContext> dbContextFactory { get; set; }

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext DBContext, UserManager<ApplicationUser> UserManager)
        {
            _context = DBContext;
            _userManager = UserManager;
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public int SaveChanges()
            => _context.SaveChanges();

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
