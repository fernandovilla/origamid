using Agendabolo.Core.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    [Table("historicoentrada")]
    public class HistoricoEntradaDTA
    {
        [Column("id"), Key]
        public int ID { get; set; }

        [Column("idhistorico")]
        public int IdHistorico { get; set; }

        [Column("idfornecedor")]
        public int IdFornecedor { get; set; }

        [Column("numeronf")]
        public long NumeroNF { get; set; }

        [Column("dataemissao")]
        public DateTime DataEmissao { get; set; }

        [Column("dataentrada")]
        public DateTime DataEntrada { get; set; }

        [Column("valorfrete")]
        public decimal ValorFrete { get; set; }

        [Column("distribuiufreteitens")]
        public bool DistribuiuFreteNosItens{ get; set; }



        public HistoricoDTA Historico { get; set; }
        public FornecedorDTA Fornecedor { get; set; }
        public IEnumerable<HistoricoEntradaItemDTA> Itens { get; set; }
    }
}
