namespace ScreenSound.Web.Response
{
    //public record MusicaResponse(int Id, string Nome, string NomeArtista);
    public class MusicaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? AnoLancamento { get; set; }
        public string Compositor { get; set; }
        public int ArtistaId { get; set; }        
        public string NomeArtista { get; set; }
        public IEnumerable<string> Generos { get; set; }

        //public virtual Artista? Artista { get; set; }
        //public virtual ICollection<Genero> Generos { get; set; } = new List<Genero>();
    }
}
