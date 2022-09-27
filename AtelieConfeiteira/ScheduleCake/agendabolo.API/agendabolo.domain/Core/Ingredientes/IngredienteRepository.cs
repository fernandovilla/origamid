using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteRepository : GenericRepository.GenericRepository<Ingrediente, ulong>, IIngredienteRepository
    {
        public IngredienteRepository(ApplicationDbContext context) 
            : base(context)
        { }
    }
}