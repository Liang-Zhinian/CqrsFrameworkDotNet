using System;
using System.Linq;

namespace MAR.Domain.Repositories
{
    public interface IReadDbRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
