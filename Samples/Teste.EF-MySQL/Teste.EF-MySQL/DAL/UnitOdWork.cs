using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.EF_MySQL.DAL.Produtos;
using Teste.EF_MySQL.DAL.Receitas;

namespace Teste.DAL
{
    internal class UnitOdWork : IDisposable
    {
        private bool _disposed;
        private readonly AppDbContext _context;

        private ProdutoRepository _produtoRepository;
        private ReceitaRepository _receitaRepository;


        public ProdutoRepository ProdutoRepository => _produtoRepository ??= new ProdutoRepository(_context);
        public ReceitaRepository ReceitaRepository => _receitaRepository ??= new ReceitaRepository(_context);



        public void Save()
        {
            _context.SaveChanges();
        }

        public UnitOdWork()
        {
            _context = new AppDbContext();                
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
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