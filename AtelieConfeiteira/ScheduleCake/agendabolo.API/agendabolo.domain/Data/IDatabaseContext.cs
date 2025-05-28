using System.Collections.Generic;
using System.Data;

namespace Agendabolo.Data
{
    public interface IDatabaseContext
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IDbCommand CreateCommand(string textCommand);

        int Execute(string textCommand);
        int Execute(string textCommand, object parameter);

        IEnumerable<T> Query<T>(string textCommand);
        IEnumerable<T> Query<T>(string textCommand, object parameter);


        IEnumerable<T> GetAll<T>() where T : class;
        T Get<T>(int id) where T : class;

        long Insert<T>(T entity) where T : class;
        bool Update<T>(T entity) where T: class;
        bool Delete<T>(T entity) where T : class;


        object ExecuteScalar(string textCommand);
        int ExecuteNonQuery(string textCommand);
    }
}
