using Sistema.Models.Core.Filiais;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Models.Core.Produtos
{
    public class Preco
    {
        public Filial Filial { get; set; }
        public TipoPreco Tipo { get; set; }
        public double Valor { get; set; }
        public DateTime InicioValidade { get; set; }
        public DateTime FimValidade { get; set; }        
    }
}
