using Agendabolo.Data;
using Agendabolo.GenericRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Agendabolo.Core.Produtos
{
    public class ProdutoRepository : GenericRepositoryDbContext<ProdutoDTA, int>, IProdutoRepository
    {
    
        public ProdutoRepository(IDatabaseContext database)
            : base (database)
        { }


        public override ProdutoDTA Get(int id)
        {
            var produto = base.Get(id);

            produto.Receitas = GetReceitas(id).ToList();

            return produto;
        }

        private IEnumerable<ProdutoReceitaDTA> GetReceitas(int produtoId)
        {
            string sql = $"SELECT * FROM ProdutosReceitas WHERE idproduto = {produtoId} ORDER BY ordem;";
            return _database.Query<ProdutoReceitaDTA>(sql);
        }

        public ProdutoDTA GetByID_Min(int id)
        {
            return Get(id);
        }


        public void Update(ProdutoDTA produto)
        {
            if (produto == null)
                throw new ArgumentNullException("Produto inválido");

            base.Update(produto);



            //Todo: concluir atualização de produtos

            //var receitasEditadas = produto.Receitas
            //    .Select(i => (ProdutoReceitaDTA)i)
            //    .ToList();

            //var receitasAtuais = _context.ProdutosReceitas
            //    .Where(i => i.IdProduto == produto.Id)
            //    .Select(i => (ProdutoReceitaDTA)i)
            //    .ToList();

            //_context.Entry(produto).State = EntityState.Modified;

            ////Receitas incluídas 
            //foreach (var receitaAdded in receitasEditadas.Where(i => i.Id == 0))
            //    _context.ProdutosReceitas.Add(receitaAdded);

            ////Atualiza receitas editadas
            //foreach (var receitaUpdated in receitasAtuais.Intersect(receitasEditadas.Where(i => i.Id > 0)))
            //    _context.Entry(receitaUpdated).State = EntityState.Modified;

            ////Remove receitas excluídas
            //var exceptReceitas = receitasAtuais.Except(receitasEditadas, new ProdutoReceitaDTA()).ToList();
            //foreach (var receitaDeleted in exceptReceitas)
            //    _context.ProdutosReceitas.Remove(receitaDeleted);
        }
    }
}
