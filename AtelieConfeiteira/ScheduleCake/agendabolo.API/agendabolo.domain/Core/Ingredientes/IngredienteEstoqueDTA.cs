using Agendabolo.Core.Fornecedores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Agendabolo.Core.Ingredientes
{
    [Table("estoqueingredientes")]
    public class IngredienteEstoqueDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idingrediente")]
        public int IngredienteId { get; set; }

        [Column("idfornecedor")]
        public int? FornecedorId { get; set; } = null;

        [Column("lote")]
        public string Lote { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Column("datafabricacao")]
        public DateTime DataFabricacao { get; set; }

        [Column("datavalidade")]
        public DateTime DataValidade { get; set; }

        
        [JsonIgnore]
        public IngredienteDTA Ingrediente { get; set; }

        [JsonIgnore]
        public FornecedorDTA Fornecedor { get; set; }

    }
}
