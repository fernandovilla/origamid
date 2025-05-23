using Agendabolo.Core.Produtos;
using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaReposiory : GenericRepository.GenericRepositoryDbContext<ReceitaDTA, int>, IReceitaRepository
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

        public override ReceitaDTA Get(int id)
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
                throw new ArgumentNullException("Receita inválida");

            var ingredientesEditados = receita.Ingredientes
                .Select(i => (ReceitaIngredienteDTA)i)
                .OrderBy(i => i.Id)
                .ToList();

            var ingredientesAtuais = _context.IngredientesReceitas
                .Where(i => i.IdReceita == receita.Id)
                .ToList();

            if (ingredientesAtuais != null)
                ingredientesAtuais.ForEach(i => _context.Entry(i).State = EntityState.Detached);


            _context.Entry(receita).State = EntityState.Modified;

            //Receitas incluídas 
            var ingredientesAdded = ingredientesEditados.Where(i => i.Id == 0);
            if (ingredientesAdded != null)
                ingredientesAdded.ToList().ForEach(i => _context.Entry(i).State = EntityState.Added);


            //Remove receitas excluídas
            var ingredientesRemoves = ingredientesAtuais.Except(ingredientesEditados, new ReceitaIngredienteComparer());
            foreach (var ingredienteDeleted in ingredientesRemoves)
                _context.IngredientesReceitas.Remove(ingredienteDeleted);


            //Atualiza receitas editadas
            var ingredientesUpdated = ingredientesEditados.Where(i => i.Id > 0).Intersect(ingredientesAtuais, new ReceitaIngredienteComparer());
            if (ingredientesUpdated != null)
                ingredientesUpdated.ToList().ForEach(i => _context.Entry(i).State = EntityState.Modified);


        }


        public void RemoveItems(IEnumerable<ReceitaIngredienteDTA> ingredientesReceita)
        {
            foreach (var item in ingredientesReceita)
                _context.IngredientesReceitas.Remove(item);
        }
    }
}
