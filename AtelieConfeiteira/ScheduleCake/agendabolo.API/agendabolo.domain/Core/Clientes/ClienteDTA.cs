using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Clientes
{
    [Table("clientes")]
    [DebuggerDisplay("{Id} | {Nome} | {Status}")]
    public class ClienteDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome")]
        public string Nome { get; set; }
        
        [Column("celular")]
        public string Celular { get; set; }
        
        [Column("telefone")]
        public string Telefone { get; set; }
        
        [Column("instagram")]
        public string Instagram { get; set; }
        
        [Column("facebook")]
        public string Facebook { get; set; }

        [Column("observacoes")]
        public string Observacoes { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
    }
}
