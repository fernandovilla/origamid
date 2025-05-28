using Agendabolo.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agendabolo.GenericRepository
{
    public class GenericRepositoryDbContext<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly IDatabaseContext _database;

        public GenericRepositoryDbContext(IDatabaseContext database)
        {
            this._database = database;
        }

        public virtual void Delete(TKey id)
        {
            var entity = Get(id);

            if (entity != null) 
                Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _database.Connection.Delete<TEntity>(entity, _database.Transaction);
        }
        

        public virtual TEntity Get(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException("Invalid id");

            return _database.Connection.Get<TEntity>(id, _database.Transaction);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _database.Connection.GetAll<TEntity>(_database.Transaction);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _database.Connection.GetAll<TEntity>(_database.Transaction).AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            return query.AsEnumerable();
        }

        public virtual void Insert(TEntity entity)
        {
            _database.Connection.Insert<TEntity>(entity, _database.Transaction);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Invalid entity");

            _database.Connection.Update<TEntity>(entity, _database.Transaction);
        }

        public int Count()
        {
            return _database.Connection.GetAll<TEntity>(_database.Transaction).Count();
        }
    }
}
