
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Models.Core.Produtos
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCadastro   Status { get; set; }
    }
}
