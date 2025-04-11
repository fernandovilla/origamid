using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    [Table("historicoentradasitenslotes")]
    public class HistoricoEntradaItemLoteDTA
    {
        [Column("id"), Key]
        public int ID { get; set; }

        [Column("identradaitem")]
        public int IdEntradaItem { get; set; }

        [Column("lote")]
        public string Lote { get; set; }

        [Column("datafabricacao")]
        public DateTime DataFabricacao { get; set; }

        [Column("datavalidade")]
        public DateTime DataValidade { get; set; }

        public HistoricoEntradaItemDTA Item { get; set; }
    }
}
