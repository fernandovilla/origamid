using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public class ProdutoRepository : GenericRepository.GenericRepository<ProdutoDTA, ulong>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context)
            : base(context)
        { }


        public override ProdutoDTA GetByID(ulong id)
        {
            IQueryable<ProdutoDTA> produtos = _dbset;

            var prod = produtos
                .Where(i => i.Id == id)
                .Include(i => i.Receitas.OrderBy(i => i.Ordem))
                .ThenInclude(i => i.Receita)
                .ThenInclude(i => i.Ingredientes.OrderBy(i => i.Ordem))
                .ThenInclude(i => i.Ingrediente)
                .FirstOrDefault();

            return prod;
        }

        public ProdutoDTA GetByID_Min(ulong id)
        {
            IQueryable<ProdutoDTA> produtos = _dbset;

            var prod = produtos
                .FirstOrDefault(i => i.Id == id);

            return prod;
        }

        public override void Update(ProdutoDTA produto)
        {
            if (produto == null)
                throw new ArgumentNullException("Invalid entity");

            //var existingProd = _context.Produtos
            //    .Where(i => i.Id == produto.Id)
            //    .Include(i => i.Receitas)
            //    .SingleOrDefault();

            ////_context.Entry(existingProd).CurrentValues.SetValues(produto);

            //foreach(var existingRec in existingProd.Receitas.ToList())
            //{
            //    if (!produto.Receitas.Any(i => i.Id == existingRec.Id))
            //        _context.ProdutosReceitas.Remove(existingRec);
            //}

            //foreach(var newRec in produto.Receitas)
            //{
            //    if (newRec.Id > 0)
            //        _context.Entry(newRec).State = EntityState.Modified;
            //    else
            //        _context.ProdutosReceitas.Add(newRec);
            //}



            _context.Entry(produto).State = EntityState.Modified;


            UpdateReceitasProduto(produto.Id, produto.Receitas);
        }

        private void UpdateReceitasProduto(ulong codigoProduto, IEnumerable<ProdutoReceitaDTA> receitasUpdate)
        {
            var existingReceitas = _context.ProdutosReceitas.Where(i => i.IdProduto == codigoProduto).ToList();

            foreach(var rec in existingReceitas)
            {
                if (!receitasUpdate.Any(i => i.Id == rec.Id))
                    _context.Remove(rec);
            }            

            foreach(var rec in receitasUpdate)
            {
                if (rec.Id == 0)
                    _context.Add(rec);
                else
                    _context.Update(rec);
            }
        }

        private void UpdateReceitasProduto2(ulong codigoProduto, IEnumerable<ProdutoReceitaDTA> receitas)
        {



            var currentChilds = _context.ProdutosReceitas.Where(i => i.IdProduto == codigoProduto);
            if (currentChilds != null)
            {
                foreach (var current in currentChilds)
                {
                    var rec = receitas.Where(i => i.Id == current.Id).FirstOrDefault();
                    if (rec == null)
                        _context.Entry<ProdutoReceitaDTA>(current).State = EntityState.Deleted;
                    else
                        _context.Entry<ProdutoReceitaDTA>(rec).State = EntityState.Modified;
                }
            }

            foreach (var rec in receitas.Where(i => i.Id == 0))
                _context.ProdutosReceitas.Add(rec);
        }
    }
}
