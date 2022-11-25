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
    public class Receita
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

        public ICollection<IngredienteReceita> Ingredientes { get; set; }

        public decimal CustoIngredientes => Ingredientes.Sum(i => i.Ingrediente.PrecoCusto * ((decimal)i.Quantidade / 1000m));
    }
}
