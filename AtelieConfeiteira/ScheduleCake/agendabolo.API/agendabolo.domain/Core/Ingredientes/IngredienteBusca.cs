using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteBuscaResponse : BuscaBaseResponse
    {
        public string Marca { get; set; }
        public double EstoqueTotal { get; set; }
    }
}
