using Agendabolo.Core.Insumos;

namespace Agendabolo.Data
{
    public interface IUnitOfWork<TDbContext> where TDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        IInsumoRepository InsumosRepository { get; }

        int Save();
    }
}
