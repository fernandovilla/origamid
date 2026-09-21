using System.ComponentModel.DataAnnotations;

namespace BlazorJWTAuth.API.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required] 
        public string Name { get; set; }

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
