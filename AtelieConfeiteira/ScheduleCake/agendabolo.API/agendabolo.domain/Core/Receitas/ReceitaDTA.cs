using Agendabolo.Core.Ingredientes;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using dapper = Dapper.Contrib.Extensions;

namespace Agendabolo.Core.Receitas
{
    [dapper.Table("receitas")]
    public partial class ReceitaDTA
    {
        [dapper.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("pesoreferencia")]
        public double PesoReferencia { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; }

        [Column("preparo")]
        public string Preparo { get; set; }

        [Column("tempopreparo")]
        public long TempoPreparo { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }

        [dapper.Computed]
        public TimeSpan TempoPreparoCalc => new TimeSpan(this.TempoPreparo);

        [dapper.Computed]
        public IEnumerable<ReceitaIngredienteDTA> Ingredientes { get; set; }
    }

    [DebuggerDisplay("{Id} | {Nome} | {Status}")]
    partial class ReceitaDTA
    {
        public static ReceitaDTA Parse(ReceitaRequest receita)
        {
            if (receita == null)
                throw new ArgumentNullException("Argument receira is invalid");


            IEnumerable<ReceitaIngredienteDTA> getIngredientesReceita(int idReceita, IEnumerable<ReceitaIngredienteRequest> ingredientes)
            {
                foreach (var item in ingredientes)
                {
                    yield return new ReceitaIngredienteDTA
                    {
                        Id = item.Id,
                        IdIngrediente = item.IdIngrediente,
                        IdReceita = idReceita,
                        Percentual = item.Percentual,
                        Ordem = item.Ordem,
                        Status = (StatusCadastro)item.Status
                    };
                }
            };

            var novaReceita = new ReceitaDTA();
            novaReceita.Id = receita.Id;
            novaReceita.Nome = receita.Nome;
            novaReceita.Descricao = receita.Descricao;
            novaReceita.Status = (StatusCadastro)receita.Status;
            novaReceita.PesoReferencia = receita.PesoReferencia;
            novaReceita.Preparo = receita.Preparo;
            novaReceita.Observacao = receita.Observacao;
            novaReceita.Ingredientes = getIngredientesReceita(receita.Id, receita.Ingredientes).ToList();

            return novaReceita;
        }

        [Computed]
        public IEnumerable<Produtos.ProdutoReceitaDTA> ProdutosReceita { get; set; }
    }
}
