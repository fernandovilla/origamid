using System;
using System.Collections.Generic;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaIngredienteRequest
    {
        public int Id { get; set; }
        public decimal Porcao { get; set; }
        public int Ordem { get; set; }
    }
}
