using Agendabolo.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public class MySQLDatabase : Database
    {
        public override IDbCommand CreateCommand(string queryCommand)
        {
            var command = ((MySqlConnection)_connection).CreateCommand();
            command.Transaction = (MySqlTransaction)base._transaction;
            command.CommandText = queryCommand;
            return command;
        }

        protected override void ClearPoolConnection(IDbConnection connection)
        {
            //if (connection is MySqlConnection)
            //    MySqlConnection.ClearPool((MySqlConnection)connection);
        }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        protected override string GetConnectionString()
        {
            var settings = AppSettings.Default;
            return settings.ConnectionStrings.DefaultConnection;
        }
    }
}
