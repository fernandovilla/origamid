using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Teste.DAL;
using Teste.EF_MySQL.DAL.GenericRepository;

namespace Teste.EF_MySQL.DAL.Produtos
{
    internal class ProdutoRepository : GenericRepository<ProdutoDTA>
    {
        public ProdutoRepository(AppDbContext context)
            : base(context)
        { }

        public override void Inserto(ProdutoDTA produto)
        {
            base.Inserto(produto);

            if (produto.Receitas != null)
            {
                foreach(var receita in produto.Receitas)
                    _context.ProdutosReceitas.Add(receita);
            }
        }

        public override void Update(ProdutoDTA produto)
        {
            var receitas = produto.Receitas
                .Select(i => (ProdutoReceitaDTA)i)
                .ToList();

            var receitasEditadas = produto.Receitas
                .Where(i => i.Id > 0)
                .Select(i => (ProdutoReceitaDTA)i)
                .ToList();

            var currentProdReceitas = _context.ProdutosReceitas
                .Where(i => i.IdProduto == produto.Id)
                .Select(i => (ProdutoReceitaDTA)i)
                .ToList();

            // Receitas incluídas
            foreach(var receitaAdded in produto.Receitas.Where(i => i.Id == 0))
                _context.ProdutosReceitas.Add(receitaAdded);

            // Receitas editadas
            foreach(var receitaEdited in currentProdReceitas.Intersect(receitasEditadas))
                _context.Entry(receitaEdited).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // Receitas excluídas
            foreach (var receitaRemoved in currentProdReceitas.Except(receitas))
                _context.ProdutosReceitas.Remove(receitaRemoved);

            base.Update(produto);
        }
    }
}
