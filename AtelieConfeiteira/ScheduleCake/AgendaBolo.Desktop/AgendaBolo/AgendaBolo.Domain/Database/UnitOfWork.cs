using AgendaBolo.Domain.Model.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Database
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IIngredienteRepository _ingredienteRepository;

        public IIngredienteRepository IngredienteReopsitory
        {
            get => _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_context));
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }

    partial class UnitOfWork : IDisposable
    {
        private bool _disposed = false;

        public UnitOfWork()
            : this(UnitOfWork.GetConnectionString())
        { }

        public UnitOfWork(string connectionString)
        {
            _context = new ApplicationDbContext(connectionString);
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        private static string GetConnectionString()
        {
            return "Host=localhost;Port=5432;Pooling=true;Database=agendabolo;User Id=postgres;Password=admin;";
        }
    }


}
