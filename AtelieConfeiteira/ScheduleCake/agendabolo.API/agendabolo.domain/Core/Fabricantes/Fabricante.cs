using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fabricantes
{
    [Table("fabricantes")]
    public class Fabricante
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("status")]
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
    }
}
