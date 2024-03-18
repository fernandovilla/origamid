using AgendaBolo.Domain.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Ingredientes
{
    public class IngredienteRepository : Repositories.GenericRepository<IngredienteDTA, uint>, IIngredienteRepository
    {
        public IngredienteRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
