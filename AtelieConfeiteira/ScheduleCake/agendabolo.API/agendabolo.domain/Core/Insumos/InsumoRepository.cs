using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Agendabolo.Core.Insumos
{
    public class InsumoRepository : GenericRepository.GenericRepository<Insumo, ulong>, IInsumoRepository
    {
        public InsumoRepository(ApplicationDbContext context) 
            : base(context)
        { }
    }
}