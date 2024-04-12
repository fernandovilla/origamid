using Npgsql.Replication.PgOutput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Ingredientes
{
    public class IngredienteDTA
    {
        public uint Id { get; set; }
        public string Nome { get; set; }
        public decimal CustoQuilo { get; set; }                
        public decimal CustoMedioQuilo { get; set; }                        
        public StatusCadastro Status { get; set; }
    }
}
