using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Insumos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public partial class UnitOfWork
    {
        private InsumoRepository _ingredienteRepository;
        private FabricanteRepository _fabricanteRepository;


        public InsumoRepository GetIngredienteRepository()
        {
            return _ingredienteRepository ?? (_ingredienteRepository = new InsumoRepository(_databaseContext));
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
