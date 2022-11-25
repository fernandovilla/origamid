using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agendabolo.GenericRepository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private ApplicationDbContext _context;
        protected DbSet<TEntity> _dbset => _context.Set<TEntity>();

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void Delete(TKey id)
        {
            if (id == null) throw new ArgumentNullException("Invalid id");

            var entity = GetByID(id);

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

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsEnumerable();
        }

        public virtual TEntity GetByID(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException("Invalid id");

            return _dbset.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Invalid entity");

            _dbset.Attach(entity);
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
