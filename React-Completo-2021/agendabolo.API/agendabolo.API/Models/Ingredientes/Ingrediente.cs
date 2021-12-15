using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models.Ingredientes
{
    public class Ingrediente
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }        
    }
}
