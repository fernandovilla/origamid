namespace ScreenSound.API.Requests
{
    //padrão DTO
    public record ArtistaRequest(string nome, string? bio, string? fotoPerfil);

    public record ArtistaRequestEdit(int id, string nome, string bio, string fotoPerfil) : ArtistaRequest(nome, bio, fotoPerfil);
    
}
