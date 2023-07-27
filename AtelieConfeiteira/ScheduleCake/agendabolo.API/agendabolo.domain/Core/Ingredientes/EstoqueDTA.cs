using Agendabolo.Core.Fornecedores;
using Agendabolo.Core.Produtos;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendabolo.Core.Ingredientes
{
    [Table("estoque")]
    public class EstoqueDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idproduto")]
        public int IdProduto { get; set; }
        [Column("idfornecedor")]
        public int IdFornecedor { get; set; }
        [Column("lote")]
        public string Lote { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Column("datafabricacao")]
        public DateTime DataFabricacao { get; set; }
        [Column("datavalidade")]
        public DateTime DataValidade { get; set; }

        public ProdutoDTA Produto { get; set; }
        public FornecedorDTA Fornecedor { get; set; }

    }
}
