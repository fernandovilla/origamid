using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteDapper
{

    [Table("ingredientes")]
    internal class Ingrediente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("marca")]
        public string Marca { get; internal set; }

        [Column("precocustoquilo")]
        public decimal PrecoCustoQuilo { get; set; }

        [Column("precocustomedio")]
        public decimal PrecoCustoMedio { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;

        [Column("dataultimoprecocusto")]
        public DateTime DataUltimoPrecoCusto { get; set; }

        [Column("tipo")]
        public TipoIngrediente Tipo { get; set; }


        public IEnumerable<Embalagem> Embalagens { get; set; }
    }

}
