using Sistema.Domain.Models.Empresas;

namespace Sistema.Domain.Models.Usuarios
{
    public enum UserRole
    {
        Default,
        Editor,
        Admin,
    }

    public class UsuarioDTO : IStatusManager
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public UserRole Role { get; set; }

        public IQueryable<EmpresaDTO>? Empresas { get; set; }


        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
