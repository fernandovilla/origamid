using System;
using System.Collections.Generic;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaIngredienteRequest
    {
        public int Id { get; set; }
        public int IdIngrediente { get; set; }
        public string Nome { get; set; }
        public double Percentual { get; set; }
        //public decimal PrecoCusto { get; set; }   
        public decimal PrecoCustoQuilo { get; set; }
        public decimal PrecoCustoMedioQuilo { get; set; }
        public int Ordem { get; set; }
        public int Status { get; set; }
    }
}
