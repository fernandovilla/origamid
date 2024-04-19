using Npgsql;
using System.Data;

namespace AgendaBolo.Domain.Database
{
    public class PostgresqlDatabase : Database
    {
        public override IDbCommand CreateCommand(string commandText)
        {
            var cmd = (NpgsqlCommand)CurrentConnection.CreateCommand();            
            cmd.Transaction = (NpgsqlTransaction)CurrentTransaction;            
            cmd.CommandText = commandText;

            return cmd;
        }

        protected override void ClearPoolConnection(IDbConnection connection)
        { }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);  
        }

        protected override string GetConnectionString()
        {
            //var ini = new Common.INI.InicializacaoPcdrug();
            //var builder = new FbConnectionStringBuilder()
            //{
            //    DataSource = ini.HostFromMapping,
            //    Database = Path.Combine(ini.PathFromMapping, DataBaseName),
            //    Port = ini.Porta,
            //    Dialect = 3,
            //    Charset = "DOS850",
            //    UserID = "SYSDBA",
            //    Password = "masterkey"
            //};

            //return builder.ToString();

            return "Host=localhost;Port=5432;Pooling=true;Database=agendabolo;User Id=postgres;Password=postgres;";
        }
    }
}
