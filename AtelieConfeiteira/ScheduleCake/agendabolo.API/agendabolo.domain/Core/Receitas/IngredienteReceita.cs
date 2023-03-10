using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Agendabolo.Core.Receitas
{
    [Table("receitasingredientes")]
    public class IngredienteReceita
    {        
        public IngredienteReceita()
        {

        }


        [Column("idreceita")]
        public ulong IdReceita { get; set; }
        [JsonIgnore]
        public Receita Receita { get; set; }

        [Column("idingrediente")]
        public ulong IdIngrediente { get; set; }
        [JsonIgnore]
        public Ingrediente Ingrediente { get; set; }


        [Key]
        [Column("id")]
        public ulong Id { get; set; }                

        [Column("nome")]
        public string Nome => Ingrediente.Nome;

        [Column("percentual")]
        public double Percentual { get; set; } = 0f;

        [Column("ordem")]
        public int Ordem { get; set; }

        public double Quantidade => Receita.Rendimento * (Percentual / 100);
        public decimal PrecoCusto => Ingrediente.PrecoCusto;        
        public decimal PrecoCustoReceita => PrecoCusto * ((decimal)Quantidade / 1000m);
    }
}
