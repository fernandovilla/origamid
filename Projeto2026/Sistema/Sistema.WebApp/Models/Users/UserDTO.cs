using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Ninegoldy.Models.Companies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ninegoldy.Models.Users
{
    public enum UserRole
    {
        Default,
        Editor,
        Admin,
    }

    [Table("Users")]
    public class UserDTO : IStatusManager
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; } = true;
        public string? PhoneNumber { get; set; }        
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public UserRole Role { get; set; } = UserRole.Admin;
        public string? ProfileImage { get; set; }
        public int AccessFailCount { get; set; } = 0;

        public IQueryable<CompanyDTO>? Empresas { get; set; }


        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
