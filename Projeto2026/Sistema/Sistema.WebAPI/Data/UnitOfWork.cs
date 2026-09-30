using Microsoft.EntityFrameworkCore;
using Sistema.Domain.Data;
using Sistema.Domain.Models.Empresas;
using Sistema.Domain.Models.Usuarios;
using Sistema.WebAPI.Data.Repositories;

namespace Sistema.WebAPI.Data
{
    partial class UnitOfWork
    {
        private IUsuarioRepository? _usuarioRepository;
        private IEmpresaRepository? _empresaRepository;

        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? (new UsuarioRepository(context));
        public IEmpresaRepository EmpresaRepository => _empresaRepository ?? (new EmpresaRepository(context));
    }


    public partial class UnitOfWork : IUnitOfWork, IDisposable
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
