using Agendabolo.Core.Pessoas;
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
    public class ClienteDTA : PessoaDTA
    {
        [Key]
        [Column("idpessoa")]
        public int IdPessoa { get; set; }
    }
}
