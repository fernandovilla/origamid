using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.GenericRepository
{
    public interface IGenericRepository<TEntity, TKey> where TEntity: class {

        TEntity GetByID(TKey id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        void Delete(TKey id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        int Count();
    }
}
