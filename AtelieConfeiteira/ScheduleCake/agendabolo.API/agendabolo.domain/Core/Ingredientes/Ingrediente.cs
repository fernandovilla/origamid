using Agendabolo.Core.Fabricantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class Ingrediente
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
        public decimal PrecoCusto { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}
