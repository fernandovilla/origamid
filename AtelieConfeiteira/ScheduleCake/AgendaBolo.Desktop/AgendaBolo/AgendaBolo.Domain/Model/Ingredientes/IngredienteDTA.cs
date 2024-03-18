using Npgsql.Replication.PgOutput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Ingredientes
{
    [Table("ingredientes")]
    public class IngredienteDTA
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("precocusto")]
        public decimal PrecoCusto { get; set; }
        
        [Column("precocustomedio")]
        public decimal PrecoCustoMedio { get; set; }
        
        [Column("quantidadeembalagem")]
        public float QuantidadeEmbalagem { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; }
    }
}
