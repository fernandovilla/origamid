using Ninegoldy.Models.Users;

namespace Ninegoldy.Models.Companies
{
    public class CompanyDTO : IStatusManager
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
        public IQueryable<UserDTO>? Usuarios { get; set; }
    }
}
