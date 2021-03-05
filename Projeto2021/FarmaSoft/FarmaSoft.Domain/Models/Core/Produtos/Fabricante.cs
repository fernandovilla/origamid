
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaSoft.Domain.Models.Core.Produtos
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCadastro   Status { get; set; }
    }
}
