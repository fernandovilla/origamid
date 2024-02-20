using Agendabolo.Core.Clientes;
using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Formas;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Produtos;
using Agendabolo.Core.Receitas;
using Agendabolo.Utils;
using System;

namespace Agendabolo.Data
{
    public partial class UnitOfWorkDbContext : IUnitOfWorkDbContext<ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        private IIngredienteRepository _ingredienteRepository;
        private IFabricanteRepository _fabricanteRepository;
        private IReceitaRepository _receitaRepository;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        private IUnidadeMedidaRepository _unidadeMedidaRepositorys;
        private IEstoqueRepository _estoqueRepository;
        private IFormaRepository _formaRepository;

        public UnitOfWorkDbContext()
            : this(UnitOfWorkDbContext.GetConnectionString())
        { }

        public UnitOfWorkDbContext(string connectionString)
        {
            _context = new ApplicationDbContext(connectionString);
        }

        public UnitOfWorkDbContext(ApplicationDbContext context)
        {
            _context = context;
        }



        public IIngredienteRepository IngredienteRepository
        {
            get => _ingredienteRepository ?? (_ingredienteRepository = new IngredienteRepository(_context));
        }

        public IFabricanteRepository FabricanteRepository
        {
            get => _fabricanteRepository ?? (_fabricanteRepository = new FabricanteRepository(_context));
        }

        public IReceitaRepository ReceitaRepository
        {
            get => _receitaRepository ?? (_receitaRepository = new ReceitaReposiory(_context));
        }

        public IProdutoRepository ProdutoRepository
        {
            get => _produtoRepository ?? (_produtoRepository = new ProdutoRepository(_context));
        }
        
        public IClienteRepository ClienteRepository
        {
            get => _clienteRepository ?? new ClienteRepository(_context);
        }

        public IUnidadeMedidaRepository UnidadeMedidaRepository
        {
            get => _unidadeMedidaRepositorys ?? new UnidadeMedidaRepository(_context);
        }

        public IEstoqueRepository EstoqueRepository
        {
            get => _estoqueRepository   ?? new IngredienteEstoqueRepository(_context);
        }


        public IFormaRepository FormaRepository
        {
            get => _formaRepository ?? new FormaRepository(_context);
        }


        IIngredienteRepository IUnitOfWork.IngredienteRepository => throw new NotImplementedException();

        IFabricanteRepository IUnitOfWork.FabricanteRepository => throw new NotImplementedException();

        IReceitaRepository IUnitOfWork.ReceitaRepository => throw new NotImplementedException();

        IProdutoRepository IUnitOfWork.ProdutoRepository => throw new NotImplementedException();

        IUnidadeMedidaRepository IUnitOfWork.UnidadeMedidaRepository => throw new NotImplementedException();

        IEstoqueRepository IUnitOfWork.EstoqueRepository => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        void IUnitOfWork.Save()
        {
            throw new NotImplementedException();
        }
    }

    public partial class UnitOfWorkDbContext : IDisposable
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
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
