using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Domain.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? AnoLancamento { get; set; }
        public string Compositor { get; set; }
        public int ArtistaId { get; set; }
        public virtual Artista? Artista { get; set; }
        public virtual ICollection<Genero> Generos { get; set; } = new List<Genero>();

        public override string ToString()
        {
            return $"Id: {Id}\n\t " +
                $"Nome: {Nome}\n\t " +
                $"Artista: {Artista?.Nome}\n\t" +
                $"Generos: {string.Join(",", Generos.Select(i => i.Nome).ToList())}";
        }
    }
}
