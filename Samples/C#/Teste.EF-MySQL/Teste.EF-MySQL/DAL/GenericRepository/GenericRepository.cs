using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teste.DAL;

namespace Teste.EF_MySQL.DAL.GenericRepository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public virtual void Delete(ulong id)
        {
            var entityToDelete = _dbset.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbset.Attach(entity);

            _dbset.Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbset;

            if (filter != null)
                query = query.Where(filter);    

            foreach(var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        public virtual TEntity GetById(ulong id)
        {
            return _dbset.Find(id);
        }

        public virtual void Inserto(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
