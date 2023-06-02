using Agendabolo.Core.Receitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    [Table("produtosreceitas")]
    public partial class ProdutoReceitaDTA
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("idProduto")]
        public ulong IdProduto { get; set; }

        [Column("idReceita")]
        public ulong IdReceita { get; set; }

        [Column("percentual")]
        public double Percentual { get; set; }

        [Column("ordem")]
        public int Ordem { get; set; }

    }

    partial class ProdutoReceitaDTA
    {
        public ProdutoReceitaDTA()
        { }

        public ProdutoReceitaDTA(ProdutoDTA produto, ReceitaDTA receita): this()
        {
            this.Produto = produto;
            this.Receita = receita;
        }

        public ProdutoDTA Produto { get; set; }

        public ReceitaDTA Receita { get; set; }
    }
}
