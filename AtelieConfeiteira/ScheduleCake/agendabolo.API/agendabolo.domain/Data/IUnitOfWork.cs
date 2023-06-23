using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Produtos;
using Agendabolo.Core.Receitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public interface IUnitOfWork: IDisposable
    {
        IIngredienteRepository IngredienteRepository { get; }
        IFabricanteRepository FabricanteRepository { get; }
        IReceitaRepository ReceitaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        void Save();
    }
}
