using Agendabolo.Core.Ingredientes;
using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.Receitas;

namespace Agendabolo.Data
{
    //public interface IUnitOfWorkDbContext<TDbContext> where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    public interface IUnitOfWorkDbContext<TDbContext> : IUnitOfWork
    {
        
    }
}
