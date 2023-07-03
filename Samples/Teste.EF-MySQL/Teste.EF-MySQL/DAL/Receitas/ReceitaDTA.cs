using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.EF_MySQL.DAL.Produtos;

namespace Teste.EF_MySQL.DAL.Receitas
{
    [Table("receitas")]
    public class ReceitaDTA
    {
        [Key]
        public ulong Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<ProdutoReceitaDTA> ProdutosReceitas { get; set; }

    }
}
