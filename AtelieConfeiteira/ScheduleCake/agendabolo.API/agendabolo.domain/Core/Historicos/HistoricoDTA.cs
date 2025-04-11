using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    public enum TipoOperacaoHistoricoEnum
    {
        EntradaMercadorias = 0,
    }

    [Table("historico")]
    public class HistoricoDTA
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("dataoperacao")]
        public DateTime DataOperacao { get; set; }

        [Column("tipooperacao")]
        public TipoOperacaoHistoricoEnum TipoOperacao { get; set; }

        [Column("idusuario")]
        public int IdUsuario { get; set; }
    }
}
