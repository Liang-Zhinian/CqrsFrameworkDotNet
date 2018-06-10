using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MAR.Application.ReadModel
{
    public class ReadModelRepositoryBase<T> : IReadModelRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context = null;
        private readonly DbSet<T> _dbSet;

        public ReadModelRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public long Count()
        {
            return _dbSet.LongCount();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet;
            }
            return _dbSet.Where(predicate);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

