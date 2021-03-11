
using System;
using System.Collections.Generic;
using System.Text;

<<<<<<< HEAD:Projeto2021/FarmaSoft/FarmaSoft.Domain/Models/Core/Produtos/Produto.cs
namespace Sistema.Models.Core.Produtos
=======
namespace FarmaSoft.Domain.Models.Core.Produtos
>>>>>>> 7ef7b76f7e31fffaa33c759c0f05b60e78e070b1:Mysql/FarmaSoft/FarmaSoft.Domain/Models/Core/Produtos/Produto.cs
{
    public class Produto
    {
        public long Id { get set }
        public string Nome { get set }
        
        public Fabricante Fabricante { get set }        
        public IEnumerable<Embalagem> Embalagens { get set }

        public StatusCadastro Status { get set }

    }
}
