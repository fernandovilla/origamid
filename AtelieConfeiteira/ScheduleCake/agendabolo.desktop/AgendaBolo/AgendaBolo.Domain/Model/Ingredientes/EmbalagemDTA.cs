using AgendaBolo.Domain.Model.UnidadesMedida;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgendaBolo.Domain.Model.Ingredientes
{
    public enum TipoEmbalagemEnum
    {
        Consumo,
        Compra
    }

    public class EmbalagemDTA
    {
        public int Id { get; set; }
        public uint IdIngrediente { get; set; }
        public uint IdUnidadeMedida { get; set; }  
        public string Descricao { get; set; }
        public string EAN { get; set; }
        public TipoEmbalagemEnum TipoEmbalagem { get; set; }
        public int Quantidade { get; set; }

        public UnidadeMedidaDTA? UnidadeMedida { get; set; }
    }
}
