using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.EF_MySQL.DAL.Produtos
{
    [Table("produtos")]
    public class ProdutoDTA
    {
        [Key]
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public IEnumerable<ProdutoReceitaDTA> Receitas { get; set; }
    }
}
