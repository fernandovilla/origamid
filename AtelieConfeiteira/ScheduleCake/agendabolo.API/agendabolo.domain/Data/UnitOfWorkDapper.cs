using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Produtos;
using Agendabolo.Core.Receitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    [Obsolete]
    public partial class UnitOfWorkDapper : IUnitOfWork
    {
        private IProdutoRepository _produtoRepository;

        public IIngredienteRepository IngredienteRepository => throw new NotImplementedException();

        public IFabricanteRepository FabricanteRepository => throw new NotImplementedException();

        public IReceitaRepository ReceitaRepository => throw new NotImplementedException();

        public IProdutoRepository ProdutoRepository
        {
            get => null;
        }

        public IUnidadeMedidaRepository UnidadeMedidaRepository => throw new NotImplementedException();

        public IEstoqueRepository EstoqueRepository => throw new NotImplementedException();
    }

    partial class UnitOfWorkDapper
    {
        private readonly IDatabase _database;
        private bool _disposed = false;

        public UnitOfWorkDapper()
        {
            _database = new MySQLDatabase();
            _database.Open();
            _database.BeginTransaction();
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
                    _database.RollbackTransaction();
                    _database.Close();
                    _database.Dispose();
                }
            }

            _disposed = true;
        }

        public void Save()
        {
            _database.CommitTransaction();
            _database.BeginTransaction();
        }

    }
}
