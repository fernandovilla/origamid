using Sistema.Data;
using Sistema.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models.Ingredientes
{
  public class IngredienteRepository : IRepositoryBase<Ingrediente, ulong>
  {
    private IDatabaseContext _databaseContext;

    public IngredienteRepository(IDatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    public void Delete(ulong id)
    {
      string sql = $"DELETE FROM ingredientes WHERE id = {id.ToSql()};";
      _databaseContext.ExecuteScalar(sql);
    }

    public ulong Insert(Ingrediente ingrediente)
    {
      var sql =
          "INSERT INTO ingredientes (nome, precocusto, status) VALUES (" +
          $"{ingrediente.Nome.ToSql()}, " +
          $"{ingrediente.PrecoCusto.ToSql()}, " +
          $"{ingrediente.Status.ToSql()});";
      var id = _databaseContext.ExecuteReturningId(sql);

      if (id != null)
        return Convert.ToUInt64(id);

      return 0u;
    }

    public Ingrediente Select(ulong id)
    {
      var sql = $"SELECT id, nome, status precocusto FROM ingredientes WHERE id = {id};";
      using (var cmd = _databaseContext.CreateCommand(sql))
      using (var reader = cmd.ExecuteReader())
      {
        if (reader.Read())
        {
          return new Ingrediente
          {
            Id = reader.GetUInt32("id"),
            Nome = reader.GetString("nome"),
            PrecoCusto = reader.GetDecimal("precocusto"),
            Status = reader.GetEnum<StatusCadastro>("status")
          };
        }
      }

      return null;
    }

    public IEnumerable<Ingrediente> SelectAll()
    {
      var sql = "SELECT id, nome, status precocusto FROM ingredientes ORDER BY nome;";
      using (var cmd = _databaseContext.CreateCommand(sql))
      using (var reader = cmd.ExecuteReader())
      {
        while (reader.Read())
        {
          yield return new Ingrediente
          {
            Id = reader.GetUInt64("id"),
            Nome = reader.GetString("nome"),
            PrecoCusto = reader.GetDecimal("precocusto"),
            Status = reader.GetEnum<StatusCadastro>("status")

          };
        }
      }
    }

    public void Update(Ingrediente ingrediente)
    {
      var sql =
         "UPDATE ingredientes SET " +
         $"nome = {ingrediente.Nome.ToSql()}, " +
         $"precocusto = {ingrediente.PrecoCusto.ToSql()}, " +
         $"status = {ingrediente.Status.ToSql()} " +
         $"WHERE id = {ingrediente.Id.ToSql()};";

      _databaseContext.ExecuteScalar(sql);
    }
  }
}
