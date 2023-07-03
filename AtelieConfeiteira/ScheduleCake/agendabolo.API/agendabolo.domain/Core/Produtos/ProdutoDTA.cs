using Agendabolo.Core.Receitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    [Table("produtos")]
    public partial class ProdutoDTA
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("observacoes")]
        public string Observacoes { get; set; }

        [Column("finalizacao")]
        public string Finalizacao { get; set; }

        [Column("pesoreferencia")]
        public int PesoReferencia { get; set; }

        [Column("tempopreparo")]
        public int TempoPreparo { get; set; }

        [Column("margempreparo")]
        public double MargemPreparo { get; set; }

        [Column("customaodeobra")]
        public decimal CustoMaoDeObra { get; set; }

        [Column("custoembalagem")]
        public decimal CustoEmbalagem { get; set; }

        [Column("margemvendavarejo")]
        public double MargemVendaVarejo { get; set; }

        [Column("precovendavarejo")]
        public decimal PrecoVendaVarejo { get; set; }

        [Column("margemvendaatacado")]
        public double MargemVendaAtacado { get; set; }

        [Column("precovendaatacado")]
        public decimal PrecoVendaAtacado { get; set; }

        public IList<ProdutoReceitaDTA> Receitas { get; set; }
    }
    
    [DebuggerDisplay("{Id} | {Nome} | {Status}")]
    partial class ProdutoDTA
    {
        public static ProdutoDTA Parse(ProdutoRequest produtoRequest)
        {
            if (produtoRequest == null)
                throw new ArgumentNullException("Argument 'produtoRequest' is invalid");

            IEnumerable<ProdutoReceitaDTA> getReceitas(int idProduto, IEnumerable<ProdutoReceitaRequest> receitas)
            {
                foreach (var receita in receitas) {
                    yield return new ProdutoReceitaDTA
                    {
                        Id = receita.Id,                        
                        IdProduto = receita.IdProduto,
                        IdReceita = receita.IdReceita,
                        Ordem = receita.Ordem,
                        Percentual = receita.Percentual
                    };
                }
            }

            var novoProduto = new ProdutoDTA();
            novoProduto.Id = produtoRequest.Id;
            novoProduto.Nome = produtoRequest.Nome;
            novoProduto.Descricao = produtoRequest.Descricao;   
            novoProduto.Observacoes = produtoRequest.Observacoes;            
            novoProduto.Status = (StatusCadastro)produtoRequest.Status;

            novoProduto.PesoReferencia = produtoRequest.PesoReferencia;
            novoProduto.TempoPreparo = produtoRequest.TempoPreparo;
            novoProduto.Finalizacao = produtoRequest.Finalizacao;

            novoProduto.MargemPreparo = 0;
            novoProduto.CustoMaoDeObra = 0;
            novoProduto.CustoEmbalagem = 0;
            novoProduto.MargemVendaVarejo = 0;
            novoProduto.PrecoVendaVarejo = 0;
            novoProduto.MargemVendaAtacado = 0;
            novoProduto.PrecoVendaAtacado = 0;            

            novoProduto.Receitas = getReceitas(produtoRequest.Id, produtoRequest.Receitas).ToList();

            return novoProduto;
        }
        
    }
}
