<<<<<<< HEAD:Projeto2021/FarmaSoft/FarmaSoft.Domain/Models/Core/Produtos/Preco.cs
﻿using Sistema.Models.Core.Filiais;
=======
﻿using FarmaSoft.Domain.Models.Core.Filiais;
>>>>>>> 7ef7b76f7e31fffaa33c759c0f05b60e78e070b1:Mysql/FarmaSoft/FarmaSoft.Domain/Models/Core/Produtos/Preco.cs
using System;
using System.Collections.Generic;
using System.Text;

<<<<<<< HEAD:Projeto2021/FarmaSoft/FarmaSoft.Domain/Models/Core/Produtos/Preco.cs
namespace Sistema.Models.Core.Produtos
=======
namespace FarmaSoft.Domain.Models.Core.Produtos
>>>>>>> 7ef7b76f7e31fffaa33c759c0f05b60e78e070b1:Mysql/FarmaSoft/FarmaSoft.Domain/Models/Core/Produtos/Preco.cs
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
