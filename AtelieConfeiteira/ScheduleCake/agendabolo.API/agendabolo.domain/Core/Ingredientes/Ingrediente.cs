using Agendabolo.Core.Fabricantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    [Table("ingredientes")]
    public class Ingrediente
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("precocusto")]
        public decimal PrecoCusto { get; set; }
        [Column("status")]
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
    }
}
