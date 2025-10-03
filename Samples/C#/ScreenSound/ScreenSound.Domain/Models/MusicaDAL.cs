using ScreenSound.Domain.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Domain.Models
{
    public class MusicaDAL : DAL<Musica>
    {
        public MusicaDAL(DatabaseContext context) 
            : base(context)
        { }
    }
}
