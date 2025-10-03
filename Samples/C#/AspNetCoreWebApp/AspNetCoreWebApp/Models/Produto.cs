using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace AspNetCoreWebApp.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [MaxLength(100), Required(ErrorMessage = "O {0} deve ser informado")]
        public string Nome { get; set; }

        [MaxLength(1000), Required(ErrorMessage = "O {0} deve ser informado")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="O {0} deve ser informado")]
        [Column(TypeName="decimal(18,4)")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O {0} deve ser informado")]
        [Column(TypeName = "integer")]
        public int Estoque { get; set; }
    }
}
