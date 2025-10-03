using ScreenSound.Domain.Database;

namespace ScreenSound.Domain.Models
{
    public class ArtistaDAL : DAL<Artista>
    {
        public ArtistaDAL(DatabaseContext context) 
            : base(context) 
        { }
    }
}
