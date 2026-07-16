using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login é obrigatório")]
        [EmailAddress]
        public string? Login { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Senha deve conter ao menos 8 caracteres")]
        public string? Senha { get; set; }        
    }
}
