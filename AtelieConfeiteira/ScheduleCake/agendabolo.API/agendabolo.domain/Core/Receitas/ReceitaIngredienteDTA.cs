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
    [Table("receitasingredientes")]
    public partial class ReceitaIngredienteDTA
    {                
        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("idreceita")]
        public ulong IdReceita { get; set; }        

        [Column("idingrediente")]
        public ulong IdIngrediente { get; set; }        

        [Column("percentual")]
        public double Percentual { get; set; } = 0f;

        [Column("ordem")]
        public int Ordem { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; } =  StatusCadastro.Normal;
    }


    [DebuggerDisplay("{Id} | {Nome} | {Status}")]
    partial class ReceitaIngredienteDTA
    {
        public ReceitaIngredienteDTA()
        { }

        public ReceitaIngredienteDTA(ReceitaDTA receita, IngredienteDTA ingrediente)
            : this()
        {
            this.Receita = receita;
            this.Ingrediente = ingrediente;
        }

        public ReceitaDTA Receita { get; set; }
        public IngredienteDTA Ingrediente { get; set; }
        public string Nome => Ingrediente?.Nome;
    }
}
