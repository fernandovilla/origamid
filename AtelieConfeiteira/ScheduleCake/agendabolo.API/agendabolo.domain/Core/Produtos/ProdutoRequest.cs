using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public partial class ProdutoRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int Status { get; set; }
        public int PesoReferencia { get; set; }
        public int TempoPreparo { get; set; }
        public string Finalizacao { get; set; }

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
                Descricao = produto.Descricao,
                Observacoes = produto.Observacoes,
                PesoReferencia = produto.PesoReferencia,
                TempoPreparo = produto.TempoPreparo,
                Finalizacao = produto.Finalizacao,
                Status = (int)produto.Status
            };

            if (produto.Receitas != null)
            {

                prod.Receitas = from receita in produto.Receitas
                                select new ProdutoReceitaRequest
                                {
                                    Id = (int)receita.Id,
                                    IdProduto = receita.IdProduto,
                                    IdReceita = receita.IdReceita,
                                    Receita = Core.Receitas.ReceitaRequest.Parse(receita.Receita),
                                    Percentual = receita.Percentual,
                                    Ordem = receita.Ordem
                                };
            }

            return prod;            
        }
    }
}
