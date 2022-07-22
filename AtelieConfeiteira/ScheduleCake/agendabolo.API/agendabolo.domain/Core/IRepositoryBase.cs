using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Core
{
    /// <summary>
    /// Repository base
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    /// <typeparam name="T2">Id Type</typeparam>
    public interface IRepositoryBase<T, T2>
    {
        IEnumerable<T> SelectAll();

        T Select(T2 id);

        T2 Insert(T entity);

        void Update(T entity);

        void Delete(T2 id);
    }
}
