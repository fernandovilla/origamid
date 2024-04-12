using AgendaBolo.Domain.Common.Extensions;
using AgendaBolo.Domain.Database;

namespace AgendaBolo.Domain.Model.Ingredientes
{
    public class IngredienteRepository : Repositories.GenericRepository<IngredienteDTA, uint>, IIngredienteRepository
    {
        public IngredienteRepository(IDatabase database)
            : base(database)
        { }

        public override IngredienteDTA GetByID(uint id)
        {
            string sql = $"SELECT * FROM ingredientes WHERE id = {id};";
            using (var reader = _database.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    return new IngredienteDTA
                    {
                        Id = (uint)reader.GetInt32("id"),
                        Nome = reader.GetString("Nome"),
                    };
                }
            }

            return null;
        }

        public IEnumerable<IngredienteBusca> Search(string value)
        {
            int codigo = 0;
            if (value.GetNumbers().Length > 0)
                codigo = int.Parse(value.GetNumbers());

            string sql =
                "select distinct \n" +
                $"  i.id as Id, \n" +
                $"  i.nome as Nome, \n" +
                $"  sum(coalesce(e.quantidade,0)) as QuantidadeEstoque\n" +
                "from ingredientes i inner join embalagensingredientes e on i.id  = e.idingrediente \n" +
                "   left join estoqueingredientes s on i.id = s.idingrediente \n" +
                $"where i.nome like '{value.Trim()}%' \n" +
                $"  or e.EAN = {value.ToSql()} \n" +
                $"  or i.id= {codigo.ToSql()} \n" +
                "group by i.id, i.nome \n" +
                "order by i.nome;";

            using (var reader = _database.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    yield return new IngredienteBusca()
                    {
                        Id = reader.GetUint("id"),
                        Nome = reader.GetString("nome"),
                        QuantidadeEstoque = reader.GetInt32("QUANTIDADEESTOQUE")
                    };
                }
            }
        }

    }
}
