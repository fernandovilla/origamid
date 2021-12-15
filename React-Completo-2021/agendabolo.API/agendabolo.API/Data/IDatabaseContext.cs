using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Data
{
    public interface IDatabaseContext: IDisposable
    {
        IDbConnection CurrentConnection { get; }
        IDbTransaction CurrentTransaction { get; }
        IDbCommand CreateCommand(string query);
        object ExecuteScalar(string query);
        object ExecuteReturningId(string query);
        IDbConnection Open();
        void Close();
        IDbTransaction BeginTrans();
        void RollbackTRans();
        void CommitTrans();
    }
}
