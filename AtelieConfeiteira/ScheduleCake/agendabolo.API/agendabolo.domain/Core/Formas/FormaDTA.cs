using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Formas
{
    [Table("formas")]
    public class FormaDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column ("pesoinicial")]
        public double PesoInicial { get; set; } = 0d;

        [Column("pesofinal")]
        public double PesoFinal { get; set; } = 0d;

        [Column("status")]
        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
    }
}
