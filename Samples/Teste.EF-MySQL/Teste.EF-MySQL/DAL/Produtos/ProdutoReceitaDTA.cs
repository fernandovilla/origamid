using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.EF_MySQL.DAL.Receitas;

namespace Teste.EF_MySQL.DAL.Produtos
{
    [Table("produtosreceitas")]
    public class ProdutoReceitaDTA
    {
        public ulong Id { get; set; }
        public ulong IdProduto { get; set; }
        public ulong IdReceita { get; set; }
        public decimal Percentual { get; set; }
        public int Ordem { get; set; }

        public ProdutoDTA Produto { get; set; }
        public ReceitaDTA Receita { get; set; }
    }
}
