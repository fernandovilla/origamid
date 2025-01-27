using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public partial class ProdutoRequest : IValidatableObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int Status { get; set; }
        public int PesoReferencia { get; set; }
        public int TempoPreparo { get; set; }
        public string Finalizacao { get; set; }

        public double MargemPreparo { get; set; }
        public decimal CustoMaoDeObra { get; set; }
        public decimal CustoEmbalagem { get; set; }
        public double MargemVendaVarejo { get; set; }        
        public decimal PrecoVendaVarejo { get; set; }
        public double MargemVendaAtacado { get; set; }
        public decimal PrecoVendaAtacado { get; set; }
        public decimal MinimoAtacado { get; set; }

        public IEnumerable<ProdutoReceitaRequest> Receitas { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(this.Nome) }));

            if (!Enum.TryParse(typeof(StatusCadastro), Status.ToString(), out object outStatus))
                results.Add(new ValidationResult("Invalid Status", new string[] { nameof(this.Status) }));

            return results;
        }
    }  

    partial class ProdutoRequest
    {
        public static ProdutoRequest ParseFromDTA(ProdutoDTA produto)
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
                MargemPreparo = produto.MargemPreparo,
                CustoEmbalagem  = produto.CustoEmbalagem,
                CustoMaoDeObra = produto.CustoMaoDeObra,
                MargemVendaVarejo = produto.MargemVendaVarejo,
                PrecoVendaVarejo = produto.PrecoVendaVarejo,
                MargemVendaAtacado = produto.MargemVendaAtacado,
                PrecoVendaAtacado = produto.PrecoVendaAtacado,
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

        public static ProdutoDTA ParseToDTA(ProdutoRequest produtoRequest)
        {
            if (produtoRequest == null)
                throw new ArgumentNullException("Argument 'produtoRequest' is invalid");

            IEnumerable<ProdutoReceitaDTA> getReceitas(int idProduto, IEnumerable<ProdutoReceitaRequest> receitas)
            {
                foreach (var receita in receitas)
                {
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

            novoProduto.MargemPreparo = produtoRequest.MargemPreparo;
            novoProduto.CustoMaoDeObra = produtoRequest.CustoMaoDeObra;
            novoProduto.CustoEmbalagem = produtoRequest.CustoEmbalagem;
            novoProduto.MargemVendaVarejo = produtoRequest.MargemVendaVarejo;
            novoProduto.PrecoVendaVarejo = produtoRequest.PrecoVendaVarejo;
            novoProduto.MargemVendaAtacado = produtoRequest.MargemVendaAtacado;
            novoProduto.PrecoVendaAtacado = produtoRequest.PrecoVendaAtacado;

            novoProduto.Receitas = getReceitas(produtoRequest.Id, produtoRequest.Receitas).ToList();

            return novoProduto;
        }
    }
}
