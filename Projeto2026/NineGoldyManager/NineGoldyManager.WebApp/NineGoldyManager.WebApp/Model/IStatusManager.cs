namespace NGManager.WebApp.Model
{
    public enum StatusCadastro
    {
        Normal = 0,
        Locked = 1,
        Deleted = 2
    }

    public interface IStatusManager
    {
        StatusCadastro Status { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
        DateTimeOffset? DeletedAt { get; set; }
    }
}
