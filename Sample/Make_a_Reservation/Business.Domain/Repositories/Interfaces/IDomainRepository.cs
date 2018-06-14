using System;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Domain.Repositories.Interfaces
{
    public interface IDomainRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
