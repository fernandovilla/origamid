using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core
{
    public class BuscaBaseResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public int Tipo { get; set; }
    }
}
