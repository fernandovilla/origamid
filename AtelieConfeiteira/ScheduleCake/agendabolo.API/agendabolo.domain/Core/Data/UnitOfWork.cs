using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public partial class UnitOfWork
    {
        private IngredienteRepository _ingredienteRepository;
        private FabricanteRepository _fabricanteRepository;


        public IngredienteRepository GetIngredienteRepository()
        {
            return _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_databaseContext));
        }

        public FabricanteRepository GetFabricanteRepository()
        {
            return _fabricanteRepository ?? (_fabricanteRepository = new FabricanteRepository(_databaseContext));
        }
    }


    public partial class UnitOfWork : IDisposable
    {
        protected readonly IDatabaseContext _databaseContext;

        public UnitOfWork()
        {
            _databaseContext = new MySqlDatabaseContext();
            _databaseContext.Open();
            _databaseContext.BeginTrans();
        }

        public void SaveChanges()
        {
            _databaseContext.CommitTrans();
            _databaseContext.BeginTrans();
        }

        public void Dispose()
        {
            _databaseContext.RollbackTRans();
            _databaseContext.Dispose();            
        }
    }
}
