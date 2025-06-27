using Agendabolo.Core.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.UnidadesNegocio
{
    [Table("usuariosunidadenegocio")]
    public class UsuarioUnidadeNegocioDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdUnidadeNegocio { get; set; }

        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
        
        public UsuarioDTA Usuario { get; set; }

        public UnidadeNegocioDTA UnidadeNegocio { get; set; }
    }
}
