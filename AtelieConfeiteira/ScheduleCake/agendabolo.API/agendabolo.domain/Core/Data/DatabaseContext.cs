using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public abstract class DatabaseContext : IDatabaseContext
    {
        private readonly string fileLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseContext.log");
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public IDbConnection CurrentConnection => _connection;
        public IDbTransaction CurrentTransaction => _transaction;


        protected abstract IDbConnection CreateNewConnection(string connectionString);
        protected abstract string GetConnectionString();
        protected virtual void ClearPoolConnection(IDbConnection connection)
        {
            
        }

        public abstract IDbCommand CreateCommand(string query);
        public abstract object ExecuteScalar(string query);
        public abstract object ExecuteReturningId(string query);
        


        public IDbConnection Open()
        {
            try
            {
                if (_connection == null || _connection.State == ConnectionState.Closed)
                    _connection = CreateNewConnection(GetConnectionString());

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
            }
            catch (Exception ex)
            {
                Core.Logs.LogDeErros.Default.Write(ex);
                throw;
            }

            return _connection;
        }

        public void Close()
        {
            if (_connection == null)
                return;

            if (_connection.State == ConnectionState.Closed)
                return;

            try
            {
                _connection.Close();
            }
            catch (Exception ex)
            {
                Core.Logs.LogDeErros.Default.Write(ex);
                throw;
            }
        }

        public IDbTransaction BeginTrans()
        {
            if (_connection == null)
                throw new NullReferenceException("connection is null");

            if (_connection.State != ConnectionState.Open)
                throw new ExecutionEngineException("connection is not open");

            try
            {
                _transaction = _transaction ?? _connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                Core.Logs.LogDeErros.Default.Write(ex);
                throw;
            }

            return _transaction;
        }

        public void CommitTrans()
        {
            if (_transaction == null)
                return;

            try
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception ex)
            {
                Core.Logs.LogDeErros.Default.Write(ex);
                throw;
            }
        }

        public void RollbackTRans()
        {
            if (_transaction == null)
                return;

            try
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception ex)
            {
                Core.Logs.LogDeErros.Default.Write(ex);
                throw;
            }
        }

        public void Dispose()
        {
            ClearPoolConnection(_connection);
            _connection?.Dispose();
        }

        
    }
}
