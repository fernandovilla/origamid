using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fornecedores
{
    [Table("fornecedores")]
    public class FornecedorDTA
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }        
        
        [Column("cnpj")]
        public string CNPJ { get; set; }

        [Column("contato")]
        public string Contato { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }


        [Column("status")]
        public StatusCadastro Status { get; set; }
    }
}
