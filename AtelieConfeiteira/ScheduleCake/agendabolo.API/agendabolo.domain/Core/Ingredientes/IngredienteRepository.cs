using Agendabolo.Core.Produtos;
using Agendabolo.Core.Receitas;
using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteRepository : GenericRepository.GenericRepositoryDbContext<IngredienteDTA, int>, IIngredienteRepository
    {        
        public IngredienteRepository(ApplicationDbContext context)
            : base(context)
        { }

        public override IEnumerable<IngredienteDTA> Get(Expression<Func<IngredienteDTA, bool>> filter = null)
        {
            System.Linq.IQueryable<IngredienteDTA> ingredientes = _dbset;

            if (filter != null)
                ingredientes = ingredientes.Where(filter);

            var i = ingredientes
                .Include(i => i.Estoque)
                .Include(i => i.Embalagens.OrderBy(i => i.Quantidade))
                .OrderBy(i => i.Nome);

            return i;
        }

        public override IngredienteDTA GetByID(int id)
        {
            return this.Get(i => i.Id == id)
                .FirstOrDefault();
        }

        public override void Update(IngredienteDTA ingrediente)
        {
            if (ingrediente == null)
                throw new ArgumentNullException(nameof(ingrediente), "Ingrediente inválido");

            var embalagensEditadas = ingrediente.Embalagens
                .Select(i => (IngredienteEmbalagemDTA)i)
                .ToList();

            var embalagensAtuais = _context.IngredientesEmbalagens
                .Where(i => i.IdIngrediente == ingrediente.Id)
                .Select(i => (IngredienteEmbalagemDTA)i)
                .ToList();

            _context.Entry(ingrediente).State = EntityState.Modified;


            if (embalagensAtuais != null)
                embalagensAtuais.ForEach(i => _context.Entry(i).State = EntityState.Detached);


            // Embalagens incluídas 
            var embalagensAdded = embalagensEditadas.Where(i => i.Id == 0);
            if (embalagensAdded != null)
                embalagensAdded.ToList().ForEach(i => _context.Entry(i).State = EntityState.Added);


            //Remove embalagens excluídas
            var embalagensRemoved = embalagensAtuais.Except(embalagensEditadas, new IngredienteEmbalagemDTA());
            if (embalagensRemoved != null)
                embalagensRemoved.ToList().ForEach(i => _context.IngredientesEmbalagens.Remove(i));


            //Atualiza receitas editadas
            var embalagensUpdated = embalagensEditadas.Where(i => i.Id > 0).Intersect(embalagensAtuais, new IngredienteEmbalagemDTA());
            if (embalagensUpdated != null)
                embalagensUpdated.ToList().ForEach(i => _context.Entry(i).State = EntityState.Modified);



            //// Embalagens Incluídas
            //foreach (var embalagem in embalagensEditadas.Where(i => i.Id == 0))
            //    _context.IngredientesEmbalagens.Add(embalagem);

            //// Embalagens Editadas
            //foreach (var embalagem in embalagensAtuais.Intersect(embalagensEditadas.Where(i =>  i.Id > 0), new IngredienteEmbalagemDTA()))
            //    _context.Entry(embalagem).State = EntityState.Modified;

            ////Atualiza receitas editadas
            ////foreach (var receitaUpdated in receitasAtuais.Intersect(receitasEditadas.Where(i => i.Id > 0)))
            ////    _context.Entry(receitaUpdated).State = EntityState.Modified;

            //// Embalagens Removidas
            //var embalagensRemoved = embalagensAtuais.Except(embalagensEditadas, new IngredienteEmbalagemDTA());
            //foreach (var embalagem in embalagensRemoved)
            //    _context.IngredientesEmbalagens.Remove(embalagem);
        }
    }
}