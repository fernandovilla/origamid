using System.ComponentModel.DataAnnotations;

namespace Ninegoldy.Models.Users
{
    public sealed class UserLogin
    {
        [Required(ErrorMessage = "E-mail não informado")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Senha não informada")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
