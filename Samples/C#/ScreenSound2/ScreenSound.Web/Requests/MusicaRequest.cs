namespace ScreenSound.Web.Requests
{
    public record MusicaRequest(string nome, int artistaId, int anoLancamento, ICollection<GeneroRequest> generos = null);
}
