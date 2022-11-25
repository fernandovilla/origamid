using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaReposiory: GenericRepository.GenericRepository<Receita, ulong>, IReceitaRepository
    {
        public ReceitaReposiory(ApplicationDbContext context)
            : base(context)
        { }


        public override IEnumerable<Receita> Get(Expression<Func<Receita, bool>> filter = null)
        {
            IQueryable<Receita> query = _dbset;

            if (filter != null)
                query = query.Where(filter);                    
        
            return query
                .Include(i => i.Ingredientes)
                .ThenInclude(i => i.Ingrediente)
                .AsEnumerable();
        }
    }
}
