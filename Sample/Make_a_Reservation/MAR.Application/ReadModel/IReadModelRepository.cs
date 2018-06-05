using System;
using System.Linq;
using System.Linq.Expressions;

namespace MAR.Application.ReadModel
{
    public interface IReadModelRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        long Count();
    }
}
