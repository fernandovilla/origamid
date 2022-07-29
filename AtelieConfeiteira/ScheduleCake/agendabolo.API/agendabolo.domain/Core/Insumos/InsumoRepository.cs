using Agendabolo.Core.Fabricantes;
using Agendabolo.Data;
using Agendabolo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Core.Insumos
{
    public class InsumoRepository : IRepositoryBase<Insumo, ulong>
    {
        private IDatabaseContext _databaseContext;

        public InsumoRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(ulong id)
        {
            string sql = $"DELETE FROM insumos WHERE id = {id.ToSql()};";
            _databaseContext.ExecuteScalar(sql);
        }

        public ulong Insert(Insumo ingrediente)
        {
            var sql =
                "INSERT INTO insumos (nome, status, precocusto) VALUES (" +
                $"{ingrediente.Nome.ToSql()}, " +
                $"{ingrediente.Status.ToSql()}, " +                
                $"{ingrediente.PrecoCusto.ToSql()});";
            var id = _databaseContext.ExecuteReturningId(sql);

            if (id != null)
                return Convert.ToUInt64(id);

            return 0u;
        }

        public Insumo Select(ulong id)
        {
            var sql = $"SELECT id, nome, status, precocusto FROM insumos WHERE id = {id};";
            using (var cmd = _databaseContext.CreateCommand(sql))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Insumo
                    {
                        Id = reader.GetUInt64("id"),
                        Nome = reader.GetString("nome"),
                        PrecoCusto = reader.GetDecimal("precocusto"),
                        Status = reader.GetEnum<StatusCadastro>("status")
                    };
                }
            }

            return null;
        }

        public IEnumerable<Insumo> SelectAll()
        {
            var sql = "SELECT id, nome, status, precocusto FROM ingredientes ORDER BY nome;";
            using (var cmd = _databaseContext.CreateCommand(sql))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Insumo
                    {
                        Id = reader.GetUInt64("id"),
                        Nome = reader.GetString("nome"),
                        PrecoCusto = reader.GetDecimal("precocusto"),
                        Status = reader.GetEnum<StatusCadastro>("status"),
                    };
                }
            }
        }

        public void Update(Insumo ingrediente)
        {
            var sql =
                "UPDATE ingredientes SET " +
                $"nome = {ingrediente.Nome.ToSql()}, " +
                $"status = {ingrediente.Status.ToSql()}, " +
                $"precocusto = {ingrediente.PrecoCusto.ToSql()} " +
                $"WHERE id = {ingrediente.Id.ToSql()};";

            _databaseContext.ExecuteScalar(sql);
        }
    }
}