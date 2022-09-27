using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Fabricantes;

namespace Agendabolo.Data
{
    public interface IUnitOfWork<TDbContext> where TDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        IIngredienteRepository IngredienteRepository { get; }
        IFabricanteRepository FabricantesRepository { get; }

        int Save();
    }
}
