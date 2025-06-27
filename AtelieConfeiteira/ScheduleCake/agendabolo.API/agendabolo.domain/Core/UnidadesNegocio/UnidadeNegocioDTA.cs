using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Agendabolo.Core.UnidadesNegocio
{

    [Table("unidadenegocio")]
    public class UnidadeNegocioDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("status")]
        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
    }
}
