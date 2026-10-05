using System.ComponentModel.DataAnnotations;

namespace Ninegoldy.Models.Users
{
    public sealed class UserRequest
    {
        [Required(ErrorMessage = "E-mail não informado")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Senha não informada")]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caractares")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não conferem")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
