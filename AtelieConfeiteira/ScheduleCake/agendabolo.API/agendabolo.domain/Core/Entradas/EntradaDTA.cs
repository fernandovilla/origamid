using Agendabolo.Core.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Entradas
{
    public class EntradaDTA
    {
        public int IdFornecedor { get; set; }
        public long NumeroNF { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal Frete { get; set; }
        public bool DistribuiuFreteNosItens { get; set; }
        public FornecedorDTA Fornecedor { get;set; }
        public IEnumerable<ItemEntradaDTA> Itens { get; set; }

    }
}
