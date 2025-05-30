using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

            receita.Ingredientes = GetIngredientes(id).ToList();

            return receita;
        }

        public IEnumerable<ReceitaIngredienteDTA> GetIngredientes(int receitaId)
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
            var currentIngredientes = GetIngredientes(receita.Id).ToList();


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
