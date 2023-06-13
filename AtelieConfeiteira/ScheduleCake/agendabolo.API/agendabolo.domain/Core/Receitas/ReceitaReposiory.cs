using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaReposiory : GenericRepository.GenericRepository<ReceitaDTA, ulong>, IReceitaRepository
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
        }

        public override ReceitaDTA GetByID(ulong id)
        {
            IQueryable<ReceitaDTA> receitas = _dbset;

            return receitas
                .Where(r => r.Id == id)
                .Include(rec => rec.Ingredientes.OrderBy(i => i.Ordem))
                .ThenInclude(i => i.Ingrediente)
                .FirstOrDefault();
        }

        public override void Update(ReceitaDTA receita)
        {
            if (receita == null)
                throw new ArgumentNullException("Invalid entity");

            _context.Entry(receita).State = EntityState.Modified;

            this.UpdateIngredientes(receita.Ingredientes);            
        }

        private void UpdateIngredientes(IEnumerable<ReceitaIngredienteDTA> ingredientesReceita)
        {
            foreach (var item in ingredientesReceita)
            {
                if (item.Id > 0)
                    if (item.Status == StatusCadastro.Excluido)
                        _context.Entry(item).State = EntityState.Deleted;
                    else
                        _context.Entry(item).State = EntityState.Modified;
                else
                    _context.Entry(item).State = EntityState.Added;
                    

                    //_context.IngredientesReceitas.Add(item);
            }
        }

        public void RemoveItems(IEnumerable<ReceitaIngredienteDTA> ingredientesReceita)
        {
            foreach (var item in ingredientesReceita)
                _context.IngredientesReceitas.Remove(item);
        }
    }
}
