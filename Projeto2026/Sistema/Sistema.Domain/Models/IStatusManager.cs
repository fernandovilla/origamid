namespace Sistema.Domain.Models
{
    public enum StatusCadastroEnum
    {
        Normal,
        Bloqueado,
        Excluido,
        Oculto
    }
    public interface IStatusManager
    {
        StatusCadastroEnum Status { get; } 
        DateTimeOffset CreateAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
        DateTimeOffset? DeletedAt { get; set; }

    }
}
