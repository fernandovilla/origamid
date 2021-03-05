
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaSoft.Domain.Models.Core.Produtos
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        
        public Fabricante Fabricante { get; set; }        
        public IEnumerable<Embalagem> Embalagens { get; set; }

        public StatusCadastro Status { get; set; }

    }
}
