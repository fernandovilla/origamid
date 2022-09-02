using Agendabolo.Core.Insumos;
using Agendabolo.Data;
using System;

namespace Agendabolo.Data
{
    public partial class UnitOfWork : IUnitOfWork<ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        private IInsumoRepository _insumoRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IInsumoRepository InsumosRepository
        {
            get => _insumoRepository ?? (_insumoRepository = new InsumoRepository(_context));
        }



        public int Save()
        {
            return _context.SaveChanges();
        }
    }

    public partial class UnitOfWork : IDisposable
    {
        private bool _disposed = false;
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
