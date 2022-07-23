using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fabricantes
{
    public class Fabricante
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
    }
}
