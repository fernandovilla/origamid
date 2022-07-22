using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public class MySqlDatabaseContext : DatabaseContext
    {
        protected override string GetConnectionString()
        {
            return "Server=localhost;Port=3306;Database=agendabolo;Uid=root;Pwd=;";
        }

        protected override IDbConnection CreateNewConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        public override IDbCommand CreateCommand(string query)
        {
            var command = new MySqlCommand(query, (MySqlConnection)CurrentConnection, (MySqlTransaction)CurrentTransaction);
            return command;
        }

        public override object ExecuteScalar(string query)
        {
            using (var cmd = (MySqlCommand)CreateCommand(query))
            {
                return cmd.ExecuteScalar();
            }
        }

        public override object ExecuteReturningId(string query)
        {
            using (var cmd = (MySqlCommand)CreateCommand(query))
            {
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
        }
    }
}
