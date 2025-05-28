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
        public ReceitaReposiory(IDatabaseContext database)
            : base(database)
        { }


        

        public override ReceitaDTA Get(int id)
        {
            var receita = base.Get(id);

            receita.Ingredientes = SelectIngredientes(id).ToList();

            return receita;
        }

        private IEnumerable<ReceitaIngredienteDTA> SelectIngredientes(int receitaId)
        {
            string sql = $"SELECT * FROM ReceitasIngredientes WHERE idReceita = {receitaId} ORDER BY ordem;";
            return _database.Query<ReceitaIngredienteDTA>(sql);
        }

        public override void Update(ReceitaDTA receita)
        {
            if (receita == null)
                throw new ArgumentNullException("Receita inválida");

            base.Update(receita);

            //Todo: Concluir atualização de receitas
            var currentIngredientes = SelectIngredientes(receita.Id).ToList();


            // Ingredientes excluídos
            var removed = currentIngredientes.Except(receita.Ingredientes, new ReceitaIngredienteComparer());
            foreach (var ingrediente in removed)
                RemoveItem(ingrediente);

            // Ingredientes atualizados
            var updated = receita.Ingredientes.Where(i => i.Id > 0);
            foreach(var ingrediente in updated)
                UpdateItem(ingrediente);

            // Ingredientes incluídos
            var added = receita.Ingredientes.Where(i => i.Id ==  0);
            foreach (var ingrediente in added)
                InsertItem(ingrediente);

        }




        public void RemoveItem(ReceitaIngredienteDTA ingredienteReceita)
        {
            _database.Delete<ReceitaIngredienteDTA>(ingredienteReceita);
        }

        public void UpdateItem(ReceitaIngredienteDTA ingredienteReceita)
        {
            _database.Update<ReceitaIngredienteDTA>(ingredienteReceita);
        }

        public void InsertItem(ReceitaIngredienteDTA ingredientereceita)
        {
            _database.Insert<ReceitaIngredienteDTA>(ingredientereceita);
        }

        public void RemoveItems(IEnumerable<ReceitaIngredienteDTA> ingredientesReceita)
        {
            throw new NotImplementedException();
        }
    }
}
