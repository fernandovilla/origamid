using System;
using System.Net.Http.Headers;
using Teste.DAL;
using Teste.EF_MySQL.DAL.Produtos;
using Teste.EF_MySQL.DAL.Receitas;

namespace Teste
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var produto = new ProdutoDTA();
            produto.Id = 1;
            produto.Nome = "BOLO DE CHOCOLATE, RECHEIO BRIGADEIRO E NINHO";
            produto.Preco = 10.80m;
            produto.Receitas = new List<ProdutoReceitaDTA>()
            {
                new ProdutoReceitaDTA() { Id = 1, IdProduto = 1, IdReceita = 1, Percentual = 50m, Ordem = 1 },
                new ProdutoReceitaDTA() { Id = 4, IdProduto = 1, IdReceita = 2, Percentual = 50m, Ordem = 0 },
            };

            using (var unit = new UnitOdWork())
            {
                var repository = unit.ProdutoRepository;
                repository.Update(produto);

                unit.Save();
            }

        }
    }
}