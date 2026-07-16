using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests
{
    //padrão DTO
    public record ArtistaRequest(
        [Required]string nome, 
        [Required]string? bio, 
        string? fotoPerfil);    

    public record ArtistaRequestEdit(
        int? id, 
        string nome, 
        string bio, 
        string? fotoPerfil)
        : ArtistaRequest(nome, bio, fotoPerfil);
}
