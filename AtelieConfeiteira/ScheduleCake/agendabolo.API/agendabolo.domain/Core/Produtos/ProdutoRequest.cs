using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public partial class ProdutoRequest
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<ProdutoReceitaRequest> Receitas { get; set; }
    }  

    partial class ProdutoRequest
    {
        public static ProdutoRequest Parse(ProdutoDTA produto)
        {
            var prod = new ProdutoRequest
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao
            };

            prod.Receitas = from receita in produto.Receitas
                            select new ProdutoReceitaRequest
                            {
                                Receita = Core.Receitas.ReceitaRequest.Parse(receita.Receita),
                                Percentual = receita.Percentual,
                                Ordem = receita.Ordem
                            };

            return prod;            
        }
    }
}
