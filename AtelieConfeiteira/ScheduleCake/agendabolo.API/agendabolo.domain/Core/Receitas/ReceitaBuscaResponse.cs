using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaBuscaResponse
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public StatusCadastro Status { get; set; }
    }
}
