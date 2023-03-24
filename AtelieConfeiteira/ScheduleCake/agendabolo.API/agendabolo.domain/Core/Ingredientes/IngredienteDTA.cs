using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Agendabolo.Core.Ingredientes
{
    [Table("ingredientes")]
    public class IngredienteDTA
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("precocusto")]
        public decimal PrecoCusto { get; set; }

        [Column("precocustomedio")]
        public decimal PrecoCustoMedio { get; set; }

        [Column("quantidadeembalagem")]
        public decimal QuantidadeEmbalagem { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;

        [JsonIgnore]
        public ICollection<Receitas.ReceitaIngredienteDTA> Receitas { get; set; }
    }
}
