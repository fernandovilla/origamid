using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AgendaBolo.Domain.Database
{
    public abstract class Database : IDatabase
    {
        protected IDbConnection _connection;
        protected IDbTransaction _transaction;

        public IDbConnection CurrentConnection => _connection;
        public IDbTransaction CurrentTransaction => _transaction;
       

        public IDbConnection Open()
        {
            if (_connection == null)
                _connection = CreateConnection(GetConnectionString());

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            return _connection;
        }

        public void Close()
        {
            if (_connection == null)
                return;

            if (_connection.State == ConnectionState.Closed)
                return;

            _connection.Close();            
        }

        public IDbTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            ClearPoolConnection(_connection);
            _connection.Dispose();
        }


        public IDataReader ExecuteReader(string commandText)
        {
            return CreateCommand(commandText).ExecuteReader();
        }

        
        protected abstract IDbConnection CreateConnection(string connectionString);
        protected abstract string GetConnectionString();
        protected abstract void ClearPoolConnection(IDbConnection connection);
        public abstract IDbCommand CreateCommand(string commandText);
    }
}
