using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Formas;
using Agendabolo.Core.Fornecedores;
using Agendabolo.Core.Historicos;
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

        public IProdutoRepository ProdutoRepository => throw new NotImplementedException();
        
        public IUnidadeMedidaRepository UnidadeMedidaRepository => throw new NotImplementedException();

        public IIngredienteEstoqueRepository EstoqueRepository => throw new NotImplementedException();

        public IFormaRepository FormaRepository => throw new NotImplementedException();

        public IFornecedorRepository FornecedorRepository => throw new NotImplementedException();

        public IHistoricoEntradaRepository HistoricoEntradaRepository => throw new NotImplementedException();
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
