using Agendabolo.Core.Fornecedores;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using dapper = Dapper.Contrib.Extensions;

namespace Agendabolo.Core.Historicos
{
    [dapper.Table("historicoentrada")]
    public class HistoricoEntradaDTA
    {
        [Column("id"), dapper.Key]
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
