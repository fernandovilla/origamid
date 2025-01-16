using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Database
{
    public interface IDatabase : IDisposable
    {
        IDbConnection CurrentConnection { get; }
        IDbTransaction CurrentTransaction { get; }

        IDbConnection Open();
        void Close();

        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();


        IDbCommand CreateCommand(string commandText);
        IDataReader ExecuteReader(string commandText);
    }
}
