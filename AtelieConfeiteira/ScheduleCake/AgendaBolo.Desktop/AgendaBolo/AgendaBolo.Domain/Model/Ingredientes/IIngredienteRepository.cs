using AgendaBolo.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Ingredientes
{
    public interface IIngredienteRepository: IGenericRepository<IngredienteDTA, uint>
    {
    }
}
