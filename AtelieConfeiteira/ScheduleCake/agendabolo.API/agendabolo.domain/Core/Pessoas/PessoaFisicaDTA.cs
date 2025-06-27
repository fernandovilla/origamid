using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Pessoas
{
    public enum GeneroPessoaEnum
    {
        NaoInformado = 0,
        Masculino = 1,
        Feminino = 2
    }

    [Table("pessoasfisicas")]
    public class PessoaFisicaDTA : PessoaDTA
    {
        [Key]
        [Column("idpessoa")]
        public int IdPessoa { get; set; }

        [Column("rg")]
        public string RG { get; set; }

        [Column("rgemissor")]
        public string RGEmissor { get; set; }

        [Column("rguf")]
        public string RGUF { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("genero")]
        public GeneroPessoaEnum Genero { get; set; }
    }
}
