using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        TEntity GetByID(TKey id);        
        void Delete(TKey id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        int Count();
    }
}
