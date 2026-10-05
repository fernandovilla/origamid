using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ninegoldy.Models.Companies;
using Ninegoldy.Models.Users;

namespace Ninegoldy.Data
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IUserRepository? _userRepository;
        private ICompanyRepository? _companyRepository;

        public IUserRepository UserRepository => _userRepository ?? (new UserRepository(_context));
        public ICompanyRepository CompanyRepository => _companyRepository ?? (new CompanyRepository(_context));


    }


    partial class UnitOfWork
    {
        [Inject]
        private IDbContextFactory<ApplicationDbContext> dbContextFactory { get; set; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext dbContext)
            => _context = dbContext;


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
