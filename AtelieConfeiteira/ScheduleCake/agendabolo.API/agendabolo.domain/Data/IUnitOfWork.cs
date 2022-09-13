using Agendabolo.Core.Insumos;
using Agendabolo.Core.Fabricantes;

namespace Agendabolo.Data
{
    public interface IUnitOfWork<TDbContext> where TDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        IInsumoRepository InsumosRepository { get; }
        IFabricanteRepository FabricantesRepository { get; }

        int Save();
    }
}
