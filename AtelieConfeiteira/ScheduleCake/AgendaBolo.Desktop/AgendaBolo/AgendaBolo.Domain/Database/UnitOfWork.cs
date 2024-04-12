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
        private readonly IDatabase _database;
        private IIngredienteRepository _ingredienteRepository;

        public IIngredienteRepository IngredienteReopsitory
        {
            get => _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_database));
        }

        public void SaveChanges()
        {
            _database.Commit();
            _database.BeginTransaction();
        }
    }

    partial class UnitOfWork : IDisposable
    {
        private bool _disposed = false;

        public UnitOfWork()
            : this(new PostgresqlDatabase())
        { }

        public UnitOfWork(IDatabase database)
        {
            _database = database;
            _database.Open();
            _database.BeginTransaction();
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
                    _database.Dispose();
                }
            }

            _disposed = true;
        }
    }


}
