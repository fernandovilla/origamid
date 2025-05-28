using Agendabolo.Core.Ingredientes;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using dapper = Dapper.Contrib.Extensions;

namespace Agendabolo.Core.Historicos
{
    [dapper.Table("historicoentradasitens")]
    public class HistoricoEntradaItemDTA
    {
        [Column("id"), dapper.Key]
        public int Id { get; set; }

        [Column("identrada")]
        public int IdEntrada { get; set; }

        [Column("idingrediente")]
        public int IdIngrediente { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Column("estoqueantes")]
        public double EstoqueAntes { get; set; }

        [Column("precocustoquiloantes")]
        public decimal PrecoCustoQuiloAntes { get; set; }

        [Column("precocustoquilobruto")]
        public decimal PrecoCustoQuiloBruto { get; set; }

        [Column("precocustoquiloliquido")]
        public decimal PrecoCustoQuiloLiquido { get; set; }

        [Column("valordesconto")]
        public decimal Desconto { get; set; }

        [Column("valorfrete")]
        public decimal Frete { get; set; }



        public HistoricoEntradaDTA Entrada { get; set; }
        public IngredienteDTA Ingrediente { get; set; }
        public IEnumerable<HistoricoEntradaItemLoteDTA> Lotes { get;set; }
    }
}
