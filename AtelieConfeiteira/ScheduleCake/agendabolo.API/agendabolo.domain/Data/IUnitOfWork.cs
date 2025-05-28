using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Formas;
using Agendabolo.Core.Fornecedores;
using Agendabolo.Core.Historicos;
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
        IIngredienteRepository GetIngredienteRepository { get; }
        IFabricanteRepository GetFabricanteRepository { get; }
        IReceitaRepository GetReceitaRepository { get; }
        IProdutoRepository GetProdutoRepository { get; }
        IUnidadeMedidaRepository GetUnidadeMedidaRepository { get; }
        IIngredienteEstoqueRepository GetEstoqueRepository { get; }
        IFormaRepository GetFormaRepository { get; }
        IFornecedorRepository GetFornecedorRepository { get; }
        IHistoricoEntradaRepository GetHistoricoEntradaRepository { get; }

        void SaveChanges();
    }
}
