using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDapper
{
    public enum StatusCadastro
    {
        Normal = 0,
        Bloqueado = 1,
        Excluido = 2,
        Oculto = 3,
    }

    public enum TipoIngrediente
    {
        Nenhum = 0,
        Insumo = 1,
        Embalagem = 2
    }

    public enum TipoEmbalagemEnum
    {
        Compra,
        Consumo
    }
}
