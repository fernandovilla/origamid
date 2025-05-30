using Agendabolo.Utils;
using MySqlConnector;
using System.Data;

namespace Agendabolo.Data
{
    public class MySQLDatabase : Database
    {
        private string connectionString;

        public MySQLDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override IDbCommand CreateCommand(string queryCommand)
        {
            var command = ((MySqlConnection)_connection).CreateCommand();
            command.Transaction = (MySqlTransaction)base._transaction;
            command.CommandText = queryCommand;
            return command;
        }

        protected override void ClearPoolConnection(IDbConnection connection)
        {
            if (connection is MySqlConnection)
                MySqlConnection.ClearPool((MySqlConnection)connection);
        }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        protected override string GetConnectionString()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                var settings = AppSettings.Default;
                this.connectionString = settings.ConnectionStrings.DefaultConnection;
            }

            return this.connectionString;
        }
    }
}
