using System;
using System.Collections.Generic;
using System.Text;

namespace Agendabolo.Core
{
    public interface IServiceBase<TEntity, TKey> where TEntity: class
    {
        int GetTotal();
        IEnumerable<TEntity> Get();
        TEntity GetByID(TKey id);
        (bool, TEntity) Save(TEntity entity);
        bool Delete(TKey id);
    }
}
