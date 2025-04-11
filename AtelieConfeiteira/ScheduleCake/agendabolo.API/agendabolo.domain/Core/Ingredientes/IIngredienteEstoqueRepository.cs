using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public interface IIngredienteEstoqueRepository : IGenericRepository<IngredienteEstoqueDTA, int>
    {
    }
}
