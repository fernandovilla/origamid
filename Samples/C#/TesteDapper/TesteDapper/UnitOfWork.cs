using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDapper
{
    internal class UnitOfWork : IDisposable
    {
        private readonly Database _database = new Database();
        private IngredienteRepository _ingredienteRepository;

        public IngredienteRepository GetIngredienteRepository()
        {
            return _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_database));   
        }

        public UnitOfWork()
        {
            _database.Open();
            _database.BeginTransaction();
        }

        public void SaveChanges()
        {
            _database.CommitTransaction();
            _database.BeginTransaction();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
