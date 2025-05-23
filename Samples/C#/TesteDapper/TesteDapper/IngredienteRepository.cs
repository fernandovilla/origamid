using Dapper.Contrib.Extensions;
using Dapper.FastCrud;

namespace TesteDapper
{
    internal class IngredienteRepository
    {
        private readonly Database _database;

        public IngredienteRepository(Database database)
        {
            _database = database;
        }


        public IEnumerable<Ingrediente> GetAll()
        {
            /*
             * FastCrud: https://github.com/MoonStorm/FastCrud/wiki
             * Dapper: https://github.com/DapperLib/Dapper/blob/main/Readme.md#features
             * 
            return _database.Connection.Find<Ingrediente>(i =>
                i.WithAlias("ing")
                .Include<Embalagem>(join => join.InnerJoin().WithAlias("emb"))
                .Where($@"{{id:of ing}} = {{idingrediente:of emb}}")
                .OrderBy($"{{nome:of ing}} ASC")
                .WithParameters(new { id = 337 }));
            */

            return _database.Connection.GetAll<Ingrediente>(_database.Transaction);
        }

        public Ingrediente Get(int id)
        {
            var ingrediente = _database.Connection.Get<Ingrediente>(id, _database.Transaction);

            if (ingrediente != null)
            {
                ingrediente.Embalagens = _database.Connection
                    .GetAll<Embalagem>(_database.Transaction)
                    .Where(i => i.IdIngrediente == id);
            }

            return ingrediente;
        }

        public Ingrediente Insert(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public Ingrediente Update(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
