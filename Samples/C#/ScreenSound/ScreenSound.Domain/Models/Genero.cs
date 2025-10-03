using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Domain.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
