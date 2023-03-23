using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public interface IReceitaRepository: IGenericRepository<ReceitaDTA, ulong>
    {
        void RemoveItems(IEnumerable<ReceitaIngredienteDTA> ingredientesReceita);
    }
}
