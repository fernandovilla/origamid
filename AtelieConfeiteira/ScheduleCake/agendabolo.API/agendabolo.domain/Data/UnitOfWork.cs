using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using Agendabolo.Utils;
using System;
using System.IO;
using System.Text.Json;

namespace Agendabolo.Data
{
    public partial class UnitOfWork : IUnitOfWork<ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        private IIngredienteRepository _ingredienteRepository;
        private IFabricanteRepository _fabricanteRepository;


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


        public IIngredienteRepository IngredienteRepository
        {
            get => _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_context));
        }

        public IFabricanteRepository FabricantesRepository
        {
            get => _fabricanteRepository ?? (_fabricanteRepository = new FabricanteRepository(_context));
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }

    public partial class UnitOfWork : IDisposable
    {
        private bool _disposed = false;

        private static string GetConnectionString()
        {
            var settings = AppSettings.Default;

            return settings.ConnectionStrings.DefaultConnection;

        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
