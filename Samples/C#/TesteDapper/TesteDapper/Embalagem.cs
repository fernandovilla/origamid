using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDapper
{
    [Table("embalagensingredientes")]
    internal class Embalagem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idingrediente")]
        [ForeignKey(nameof(Ingrediente))]
        public int IdIngrediente { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }

        [Column("ean")]
        public string EAN { get; set; }

        [Column("idunidademedida")]
        public int IdUnidadeMedida { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Column("tipoembalagem")]
        public TipoEmbalagemEnum TipoEmbalagem { get; set; }

        public Ingrediente Ingrediente { get; set; }
    }
}
