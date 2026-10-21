using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Gestao.App.Data.Repositories;
using Gestao.Domain.Repositories;
//using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using Gestao.Domain.Model.Users;
using Gestao.Domain.Model.Companies;

namespace Gestao.App.Data
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {        
        private ICompanyRepository? _companyRepository;
        private ICustomerRepository? _customerRepository;

        

        
        public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_context);
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);
    }


    partial class UnitOfWork
    {
     
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
