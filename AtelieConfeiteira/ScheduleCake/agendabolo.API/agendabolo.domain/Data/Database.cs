using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public abstract class Database : IDatabase
    {
        protected IDbConnection _connection;
        protected IDbTransaction _transaction;

        protected abstract string GetConnectionString();
        protected abstract IDbConnection CreateConnection(string connectionString);
        protected abstract void ClearPoolConnection(IDbConnection connection);
        public abstract IDbCommand CreateCommand(string textCommand);


        public IDbConnection Connection => _connection;

        public IDbTransaction Transaction => _transaction;

        public IDbTransaction BeginTransaction()
        {
            if (_transaction == null)
                _transaction = _connection.BeginTransaction();

            return _transaction;
        }

        public void Close()
        {
            if (_connection == null)
                return;

            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            ClearPoolConnection(_connection);
            _connection.Dispose();
        }

        public IDbConnection Open()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
                _connection = CreateConnection(GetConnectionString());

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            return _connection;
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public virtual object ExecuteScalar(string textCommand)
        {
            using(var command = CreateCommand(textCommand))
                return command.ExecuteScalar();
        }

        public virtual int ExecuteNonQuery(string textCommand)
        {
            using (var command = CreateCommand(textCommand))
                return command.ExecuteNonQuery();
        }
    }
}
