using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Entradas
{
    public class ItemEntradaDTA
    {
        public int IdIngrediente { get; set; }
        public double Quantidade { get; set; }
        public double EstoqueAntes { get; internal set; }
        public decimal PrecoCustoQuiloBruto { get; internal set; }
        public decimal PrecoCustoQuiloLiquido { get; internal set; }
        public decimal Frete { get; internal set; }
        public decimal Desconto { get; internal set; }

        public IEnumerable<ItemEntradaLoteDTA> Lotes { get; set; }
        

    }
}
