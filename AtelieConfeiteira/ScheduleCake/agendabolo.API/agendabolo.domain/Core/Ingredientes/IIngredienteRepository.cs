using System;
using System.Collections.Generic;
using System.Text;
using Agendabolo.GenericRepository;

namespace Agendabolo.Core.Ingredientes
{
    public interface IIngredienteRepository : IGenericRepository<IngredienteDTA, ulong>
    {
    }
}
