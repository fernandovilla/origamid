using Agendabolo.Core.Fabricantes;
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



        public void Save()
        {
            _context.SaveChanges();
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
                    //_context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
