using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public interface IDatabase: IDisposable
    {
        IDbConnection Connection { get; }  
        IDbTransaction Transaction { get; }
        IDbConnection Open();
        void Close();        
        IDbTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IDbCommand CreateCommand(string textCommand);
        object ExecuteScalar(string textCommand);
        int ExecuteNonQuery(string textCommand);
    }
}
