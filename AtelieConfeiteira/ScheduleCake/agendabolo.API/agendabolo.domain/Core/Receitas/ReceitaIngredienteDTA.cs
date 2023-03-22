using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace Agendabolo.Core.Receitas
{
    [DebuggerDisplay("{Id} {Status}")]
    [Table("receitasingredientes")]
    public class ReceitaIngredienteDTA
    {        
        public ReceitaIngredienteDTA()
        {  }

        public ReceitaIngredienteDTA(ReceitaDTA receita, IngredienteDTA ingrediente)
            : this()
        {
            this.Receita = receita;
            this.Ingrediente = ingrediente;
        }


        


        public string Nome => Ingrediente?.Nome;



        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("idreceita")]
        public ulong IdReceita { get; set; }
        [JsonIgnore]
        public ReceitaDTA Receita { get; set; }

        [Column("idingrediente")]
        public ulong IdIngrediente { get; set; }

        [JsonIgnore]
        public IngredienteDTA Ingrediente { get; set; }

        [Column("percentual")]
        public double Percentual { get; set; } = 0f;

        [Column("ordem")]
        public int Ordem { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; } =  StatusCadastro.Normal;

        public double Quantidade => Receita == null ? 0 : Receita.Rendimento * (Percentual / 100);
        public decimal PrecoCusto => (Ingrediente != null ? Ingrediente.PrecoCusto : 0m);
        public decimal PrecoCustoReceita => PrecoCusto * ((decimal)Quantidade / 1000m);
    }
}
