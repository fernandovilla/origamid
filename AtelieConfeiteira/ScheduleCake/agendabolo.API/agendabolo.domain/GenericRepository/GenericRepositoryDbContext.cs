using Agendabolo.Data;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agendabolo.GenericRepository
{
    public class GenericRepositoryDbContext<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<TEntity> _dbset => _context.Set<TEntity>();

        public GenericRepositoryDbContext(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void Delete(TKey id)
        {
            if (id == null) throw new ArgumentNullException("Invalid id");

            var entity = Get(id);

            if (entity == null) throw new KeyNotFoundException("Entity not found");

            this.Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("Invalid entity");

            if (_context.Entry(entity).State == EntityState.Detached)
                _dbset.Attach(entity);

            _dbset.Remove(entity);
        }

        

        public virtual TEntity Get(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException("Invalid id");

            return _context.Connection.Get<TEntity>(id, _context.Transaction);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _context.Connection.GetAll<TEntity>(_context.Transaction);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbset;

            //_context.Connection.GetAll<TEntity>(_context.Transaction)
            //    .Where(filter);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsEnumerable();
        }

        public virtual void Insert(TEntity entity)
        {
            //if (entity == null)
            //    throw new ArgumentNullException("Invalid entity");

            //_dbset.Attach(entity);

            _context.Connection.Insert<TEntity>(entity, _context.Transaction);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Invalid entity");

            _dbset.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return _dbset.Count();
        }
    }
}
