using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    [Table("receitas")]
    public class ReceitaDTA
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; }

        [Column("rendimento")]
        public int Rendimento { get; set; } = 1000;

        [Column("preparo")]
        public string Preparo { get; set; }

        [Column("cozimento")]
        public string Cozimento { get; set; }

        
        [Column("margemCustoPreparo")]
        public decimal MargemCustoPreparo { get; set; }

        [Column("precoCustoPreparo")]
        public decimal PrecoCustoPreparo { get; set; }

        [Column("margemVendaAtacado")]
        public decimal MargemVendaAtacado { get; set; }

        [Column("precoVendaAtacado")]
        public decimal PrecoVendaAtacado { get; set; }
        
        [Column("margemVendaVarejo")]
        public decimal MargemVendaVarejo { get; set; }

        [Column("precoVendaVarejo")]
        public decimal PrecoVendaVarejo { get; set; }

        public List<ReceitaIngredienteDTA> Ingredientes { get; set; }

        public static ReceitaDTA Parse(ReceitaRequest receita)
        {
            if (receita == null)
                throw new ArgumentNullException("Argument receira is invalid");


            IEnumerable<ReceitaIngredienteDTA> getIngredientesReceita(int idReceita, IEnumerable<ReceitaIngredienteRequest> ingredientes)
            {
                foreach(var item in ingredientes)
                {
                    yield return new ReceitaIngredienteDTA
                    {
                        Id = (ulong)item.Id,
                        IdIngrediente = (ulong)item.IdIngrediente,
                        IdReceita = (ulong)idReceita,
                        Percentual = item.Percentual,
                        Ordem = item.Ordem,
                        Status = (StatusCadastro)item.Status
                    };
                }
            };

            var novaReceita = new ReceitaDTA();
            novaReceita.Id = (ulong)receita.Id;
            novaReceita.Nome = receita.Nome;
            novaReceita.Descricao = receita.Descricao;
            novaReceita.Rendimento = receita.Rendimento;
            novaReceita.Status = (StatusCadastro)receita.Status;
            novaReceita.Preparo = receita.Preparo;
            novaReceita.Cozimento = receita.Cozimento;
            novaReceita.Ingredientes = getIngredientesReceita(receita.Id, receita.Ingredientes).ToList();

            return novaReceita;

        }

        //public decimal CustoIngredientes => Ingredientes.Sum(i => i.Ingrediente.PrecoCusto * ((decimal)i.Quantidade / 1000m));
    }
}
