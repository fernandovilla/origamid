using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agendabolo.Data
{
    public partial class UnitOfWork
    {
        // Repositories...
    }


    public partial class UnitOfWork : IDisposable
    {
        protected readonly IDatabaseContext _databaseContext;

        public UnitOfWork()
        {
            _databaseContext = new MySqlDatabaseContext();
            _databaseContext.BeginTrans();
        }

        public void SaveChanges()
        {
            _databaseContext.CommitTrans();
            _databaseContext.BeginTrans();
        }

        public void Dispose()
        {
            _databaseContext.RollbackTRans();
            _databaseContext.Dispose();            
        }
    }
}
