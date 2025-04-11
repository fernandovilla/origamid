using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Entradas
{
    public class ItemEntradaRequest
    {
        public int IdIngrediente { get; set; }
        public double Quantidade { get; set; }
        public double EstoqueAntes { get; set; }
        public decimal PrecoCustoQuiloBruto { get; set; }
        public decimal PrecoCustoQuiloLiquido { get; set; }
        public decimal Desconto { get; set; }
        public decimal Frete { get; set; }

        public string Lote { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
