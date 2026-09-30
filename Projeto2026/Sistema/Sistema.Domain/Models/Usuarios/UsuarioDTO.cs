using Sistema.Domain.Models.Empresas;

namespace Sistema.Domain.Models.Usuarios
{
    public class UsuarioDTO : IStatusManager
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public Guid CompaniaId { get; set; }
        public EmpresaDTO Empresa { get; set; }


        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
