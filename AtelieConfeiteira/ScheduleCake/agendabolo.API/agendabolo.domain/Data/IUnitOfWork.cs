using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Receitas;

namespace Agendabolo.Data
{
    public interface IUnitOfWork<TDbContext> where TDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        IIngredienteRepository IngredienteRepository { get; }
        IFabricanteRepository FabricantesRepository { get; }        
        IReceitaRepository ReceitasRepository { get; }

        int Save();
    }
}
