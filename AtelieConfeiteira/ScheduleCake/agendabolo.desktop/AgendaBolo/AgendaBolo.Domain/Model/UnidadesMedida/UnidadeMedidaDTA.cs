using AgendaBolo.Domain.Model.Ingredientes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaBolo.Domain.Model.UnidadesMedida
{
    public class UnidadeMedidaDTA
    {
        public uint Id { get; set; }

        public string Unidade { get; set; }

        public string UnidadeAbreviada { get; set; }
    }
}