using Agendabolo.Core.Receitas;
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

            var receitas = GetReceitas(id);

            if (receitas.Any())
                produto.Receitas = receitas.ToList();

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

        public override void Insert(ProdutoDTA produto)
        {
            base.Insert(produto);

            if (produto.Receitas != null)
            {
                foreach(var receita in produto.Receitas)
                    InsertReceita(receita);
            }
        }

        public void InsertReceita(ProdutoReceitaDTA receita)
        {
            string sql = "INSERT INTO produtosreceitas (idproduto, idreceita, percentual, ordem) values (@idproduto, @idreceita, @percentual, @ordem);";
            _database.Execute(sql, receita);
        }

        public void UpdateReceita(ProdutoReceitaDTA receita)
        {
            string sql = "UPDATE produtosreceitas SET " +
                "percentual = @percentual, " +
                "ordem = @ordem " +
                "WHERE id = @id;";
            _database.Execute(sql, receita);
        }

        public void RemoveReceita(ProdutoReceitaDTA receita)
        {
            _database.Delete<ProdutoReceitaDTA>(receita);
        }

        public void Update(ProdutoDTA produto)
        {
            if (produto == null)
                throw new ArgumentNullException("Produto inválido");

            base.Update(produto);

            if (produto.Receitas != null)
            {
                var currentReceitas = GetReceitas(produto.Id).ToList();
                
                // Receitas atualizadas
                var updated = produto.Receitas.Where(i => i.Id > 0);
                foreach (var receita in updated)
                    UpdateReceita(receita);

                // Receitas incluídas
                var added = produto.Receitas.Where(i => i.Id == 0);
                foreach (var receita in added)
                    InsertReceita(receita);

                // Receitas removidas
                var removed = currentReceitas.Except(produto.Receitas, new ProdutoReceitaComparer());
                foreach (var receita in removed)
                    RemoveReceita(receita);
            }
        }
    }
}
