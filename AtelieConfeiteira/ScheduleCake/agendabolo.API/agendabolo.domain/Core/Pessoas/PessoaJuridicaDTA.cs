using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Agendabolo.Core.Pessoas
{
    [Table("pessoajuridica")]
    public class PessoaJuridicaDTA : PessoaDTA
    {
        [Key]        
        [Column("idpessoa")]
        public int IdPessoa { get; set; }

        [Column("razaosocial")]
        public string RazaoSocial { get; set; }

        [Column("contato")]
        public string Contato { get; set; }

        [Column("cnpj")]
        public string CNPJ { get; set; }

        [Column("ie")]
        public string IE { get; set; }
    }
}
