using Agendabolo.Data;
using Agendabolo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fabricantes
{
    public class FabricanteRepository : IRepositoryBase<Fabricante, ulong>
    {
        private IDatabaseContext _databaseContext;

        public FabricanteRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(ulong id)
        {
            var sql = $"DELETE FROM fabricantes WHERE id = {id.ToSql()};";
            _databaseContext.ExecuteScalar(sql);
        }

        public ulong Insert(Fabricante fabricante)
        {
            var sql =
                "INSERT INTO fabricantes (nome, status) VALUES (" +
                $"{fabricante.Nome.ToSql()}, " +
                $"{fabricante.Status.ToSql()});";
            var id = _databaseContext.ExecuteReturningId(sql);

            if (id != null)
                return Convert.ToUInt64(id);

            return 0u;
        }

        public Fabricante Select(ulong id)
        {
            var sql = $"SELECT id, nome, status FROM fabricantes WHERE id = {id.ToSql()};";
            using (var cmd = _databaseContext.CreateCommand(sql))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Fabricante
                    {
                        Id = reader.GetUInt32("id"),
                        Nome = reader.GetString("nome"),
                        Status = reader.GetEnum<StatusCadastro>("status")
                    };
                }
            }

            return null;
        }

        public IEnumerable<Fabricante> SelectAll()
        {
            var sql = "SELECT id, nome, status FROM fabricantes ORDER BY nome;";
            using (var cmd = _databaseContext.CreateCommand(sql))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Fabricante
                    {
                        Id = reader.GetUInt64("id"),
                        Nome = reader.GetString("nome"),
                        Status = reader.GetEnum<StatusCadastro>("status")
                    };
                }
            }
        }

        public void Update(Fabricante entity)
        {
            throw new NotImplementedException();
        }
    }
}