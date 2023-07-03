using Agendabolo.Core.Receitas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    [Table("produtosreceitas")]
    public partial class ProdutoReceitaDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idProduto")]
        public int IdProduto { get; set; }

        [Column("idReceita")]
        public int IdReceita { get; set; }

        [Column("percentual")]
        public double Percentual { get; set; }

        [Column("ordem")]
        public int Ordem { get; set; }

    }

    partial class ProdutoReceitaDTA : IEqualityComparer<ProdutoReceitaDTA>
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

        public override bool Equals(object obj)
        {
            var rec = obj as ProdutoReceitaDTA;

            if (rec == null)
                return false;

            return this.Id == rec.Id;
        }

        public bool Equals(ProdutoReceitaDTA x, ProdutoReceitaDTA y)
        {
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] ProdutoReceitaDTA obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;

            return obj.Id.GetHashCode();
        }
    }
}
