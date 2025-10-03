using ScreenSound.Domain.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Domain.Models
{
    public class GeneroDAL : DAL<Genero>
    {
        public GeneroDAL(DatabaseContext context) 
            : base(context)
        { }
    }
}
