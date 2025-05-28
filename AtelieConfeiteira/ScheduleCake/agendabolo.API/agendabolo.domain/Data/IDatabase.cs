using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Data
{
    public interface IDatabase : IDatabaseContext,  IDisposable
    {
        IDbConnection Open();
        void Close();        
        IDbTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();        
    }
}
