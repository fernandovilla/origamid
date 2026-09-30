namespace Sistema.Domain.Models.Empresas
{
    public class EmpresaDTO : IStatusManager
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
