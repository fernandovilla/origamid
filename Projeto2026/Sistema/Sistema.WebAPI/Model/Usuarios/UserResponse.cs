using Sistema.Domain.Models.Usuarios;
using Sistema.WebAPI.Model.Empresas;

namespace Sistema.WebAPI.Model.Usuarios
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public IEnumerable<EmpresaResponse> Empresas { get; set; }
    }
}
