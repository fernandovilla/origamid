using Agendabolo.Core.Entradas;
using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    [Table("historicoentradasitens")]
    public class HistoricoEntradaItemDTA
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("idhistoricoentrada")]
        public int EntradaId { get; set; }

        [Column("idingrediente")]
        public int IngredienteId { get; set; }

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
