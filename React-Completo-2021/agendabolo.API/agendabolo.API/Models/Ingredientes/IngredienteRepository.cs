using agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agendabolo.Models.Ingredientes
{
    public class IngredienteRepository: IRepositoryBase<Ingrediente, int>
    {
        private IDatabaseContext _databaseContext;

        public IngredienteRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Ingrediente ingrediente)
        {
            var sql = 
                "INSERT INTO ingredientes VALUES (" +
                $"{ingrediente.Nome}, " +
                $"{ingrediente.PrecoCusto});";

            using (var cmd = _databaseContext.CreateCommand(""))
            {

            }
        }

        public Ingrediente Select(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingrediente> SelectAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }
    }
}
