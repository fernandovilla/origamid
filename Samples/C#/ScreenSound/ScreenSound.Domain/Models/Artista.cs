namespace ScreenSound.Domain.Models
{
    public class Artista
    {
        

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string FotoPerfil { get; set; } = "https://i.pinimg.com/1200x/c3/41/33/c34133dc94a8d578218b45f60ef47b6d.jpg";
        public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

        public void AdicionarMusica(Musica musica)
        {
            Musicas.Add(musica);
        }

        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia do artista {Nome}");
            foreach (var musica in Musicas)
            {
                Console.WriteLine($"Música: {musica.Nome} - Ano de Lançamento: {musica.AnoLancamento}");
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}\n\t Nome: {Nome}\n\t Bio: {Bio}";
        }
    }
}
