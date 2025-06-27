using Agendabolo.Core.Pessoas;
using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Formas;
using Agendabolo.Core.Fornecedores;
using Agendabolo.Core.Historicos;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Produtos;
using Agendabolo.Core.Receitas;
using Agendabolo.Utils;
using System;

namespace Agendabolo.Data
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabase _database;

        private IIngredienteRepository _ingredienteRepository;
        private IFabricanteRepository _fabricanteRepository;
        private IReceitaRepository _receitaRepository;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        private IUnidadeMedidaRepository _unidadeMedidaRepositorys;
        private IIngredienteEstoqueRepository _estoqueRepository;
        private IFormaRepository _formaRepository;
        private IFornecedorRepository _fornecedorRepository;
        private IHistoricoEntradaRepository _historicoEntradaRepository;

        public UnitOfWork()
        {
            _database = new MySQLDatabase(GetConnectionString());
            _database.Open();
            _database.BeginTransaction();
        }

        //public UnitOfWork(string connectionString)
        //{
        //    _database = new MySQLDatabase(connectionString);
        //    _database.Open();
        //    _database.BeginTransaction();
        //}

        //public UnitOfWork(IDatabase database)
        //{
        //    _database = database;
        //    _database.Open();
        //    _database.BeginTransaction();
        //}



        public IIngredienteRepository GetIngredienteRepository
        {
            get => _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_database));
        }

        public IFabricanteRepository GetFabricanteRepository
        {
            get => _fabricanteRepository ?? (_fabricanteRepository = new FabricanteRepository(_database));
        }

        public IReceitaRepository GetReceitaRepository
        {
            get => _receitaRepository ?? (_receitaRepository = new ReceitaReposiory(_database));
        }

        public IProdutoRepository GetProdutoRepository
        {
            get => _produtoRepository ?? (_produtoRepository = new ProdutoRepository(_database));
        }

        public IClienteRepository GetClienteRepository
        {
            get => _clienteRepository ?? new ClienteRepository(_database);
        }

        public IUnidadeMedidaRepository GetUnidadeMedidaRepository
        {
            get => _unidadeMedidaRepositorys ?? new UnidadeMedidaRepository(_database);
        }

        public IIngredienteEstoqueRepository GetEstoqueRepository
        {
            get => _estoqueRepository ?? new IngredienteEstoqueRepository(_database);
        }

        public IFormaRepository GetFormaRepository
        {
            get => _formaRepository ?? new FormaRepository(_database);
        }

        public IFornecedorRepository GetFornecedorRepository
        {
            get => _fornecedorRepository ?? new FornecedorRepository(_database);
        }

        public IHistoricoEntradaRepository GetHistoricoEntradaRepository
        {
            get => _historicoEntradaRepository ?? new HistoricoEntradaRepository(_database);
        }


        IIngredienteRepository IUnitOfWork.GetIngredienteRepository => this.GetIngredienteRepository;
        IFabricanteRepository IUnitOfWork.GetFabricanteRepository => this.GetFabricanteRepository;
        IReceitaRepository IUnitOfWork.GetReceitaRepository => this.GetReceitaRepository;
        IProdutoRepository IUnitOfWork.GetProdutoRepository => this.GetProdutoRepository;
        IUnidadeMedidaRepository IUnitOfWork.GetUnidadeMedidaRepository => this.GetUnidadeMedidaRepository;
        IIngredienteEstoqueRepository IUnitOfWork.GetEstoqueRepository => this.GetEstoqueRepository;
        IFormaRepository IUnitOfWork.GetFormaRepository => this.GetFormaRepository;
        IFornecedorRepository IUnitOfWork.GetFornecedorRepository => this.GetFornecedorRepository;
        IHistoricoEntradaRepository IUnitOfWork.GetHistoricoEntradaRepository => this.GetHistoricoEntradaRepository;



        public void SaveChanges()
        {
            _database.CommitTransaction();
            _database.BeginTransaction();
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        void IUnitOfWork.SaveChanges()
        {
            throw new NotImplementedException();
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
                    _database.RollbackTransaction();
                    _database.Close();
                    _database.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
