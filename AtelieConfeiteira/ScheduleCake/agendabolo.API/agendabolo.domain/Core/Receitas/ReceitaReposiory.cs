using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaReposiory: GenericRepository.GenericRepository<ReceitaDTA, ulong>, IReceitaRepository
    {
        public ReceitaReposiory(ApplicationDbContext context)
            : base(context)
        { }


        public override IEnumerable<ReceitaDTA> Get(Expression<Func<ReceitaDTA, bool>> filter = null)
        {
            IQueryable<ReceitaDTA> query = _dbset;

            if (filter != null)
                query = query.Where(filter);

            return query.AsEnumerable();

            //return query
            //    .Include(i => i.Ingredientes)
            //    .ThenInclude(i => i.Ingrediente)
            //    .AsEnumerable();
        }

        public override ReceitaDTA GetByID(ulong id)
        {
            IQueryable<ReceitaDTA> receitas = _dbset;

            return receitas
                .Where(r => r.Id == id)
                .Include(rec => rec.Ingredientes)
                .ThenInclude(i => i.Ingrediente)                
                .FirstOrDefault();
        }
    }
}
