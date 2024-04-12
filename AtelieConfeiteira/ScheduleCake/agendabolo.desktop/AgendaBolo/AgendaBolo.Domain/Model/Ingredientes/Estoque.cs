using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Ingredientes
{
    public class EstoqueDTA
    {
        public uint Id { get; set; }
        public uint IdIngrediente { get; set; }       
        public string Lote { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
    }
}
