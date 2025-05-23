using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDapper
{
    internal class Database : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public IDbConnection Connection => _transaction?.Connection  ?? _connection;
        public IDbTransaction Transaction => _transaction;

        public Database()
        {
            _connection = CreateConnection();
        }

        private IDbConnection CreateConnection()
        {
            var builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.Database = "controle";
            builder.UserID = "root";
            builder.Password = "root";

            return new MySqlConnection(builder.ToString());
        }

        public IDbConnection Open()
        {
            if (_connection == null)
                _connection = CreateConnection();

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            return _connection;
        }

        public void Close()
        {
            if (_connection == null || _connection?.State == ConnectionState.Closed)
                return;

            RollbackTransaction();

            _transaction = null;
            _connection.Close();
        }

        public IDbTransaction BeginTransaction()
        {
            if (_transaction == null || _transaction?.Connection == null)
                _transaction = _connection.BeginTransaction();

            return _transaction;
        }

        public void CommitTransaction()
        {
            if (_transaction == null || _transaction?.Connection == null)
                return;

            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (_transaction == null || _transaction?.Connection == null)
                return;

            _transaction.Rollback();
        }


        public void Dispose()
        {
            if (_transaction != null)
            {
                RollbackTransaction();
                _transaction.Dispose();
            }

            if (_connection != null)
            {
                Close();
                _connection.Dispose();
            }                
        }
    }
}
