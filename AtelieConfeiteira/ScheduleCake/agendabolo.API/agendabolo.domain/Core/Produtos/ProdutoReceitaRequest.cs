using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public partial class ProdutoReceitaRequest
    {
        public Receitas.ReceitaRequest Receita { get; set; }
        public double Percentual { get; set; }
        public int Ordem { get; set; }

        public static ProdutoReceitaRequest Parse(ProdutoReceitaDTA produtoReceita) {

            return new ProdutoReceitaRequest()
            {
                Receita = Receitas.ReceitaRequest.Parse(produtoReceita.Receita),
                Percentual = produtoReceita.Percentual,
                Ordem = produtoReceita.Ordem
            };
        }
    }

    
}
