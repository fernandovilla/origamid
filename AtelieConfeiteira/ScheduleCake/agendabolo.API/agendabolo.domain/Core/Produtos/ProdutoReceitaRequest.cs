using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public partial class ProdutoReceitaRequest
    {
        [JsonIgnore]
        public Receitas.ReceitaRequest Receita { get; set; }

        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdReceita { get; set; }
        public string Nome => this.Receita?.Nome;
        public IEnumerable<Receitas.ReceitaIngredienteRequest> Ingredientes => this.Receita?.Ingredientes;
        public double Percentual { get; set; }
        public int Ordem { get; set; }

        public static ProdutoReceitaRequest Parse(ProdutoReceitaDTA produtoReceita)
        {
            return new ProdutoReceitaRequest()
            {
                Receita = Receitas.ReceitaRequest.Parse(produtoReceita.Receita),
                Percentual = produtoReceita.Percentual,
                Ordem = produtoReceita.Ordem
            };
        }
    }
}