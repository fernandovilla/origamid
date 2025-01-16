using AgendaBolo.Domain.Database;
using AgendaBolo.Domain.Model.Ingredientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Model.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly IDatabase _database;
        
        public GenericRepository(IDatabase database)
        {
            _database = database;
        }

        public virtual void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetByID(TKey id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Search(string value)
        {
            throw new NotImplementedException();
        }
    }
}
