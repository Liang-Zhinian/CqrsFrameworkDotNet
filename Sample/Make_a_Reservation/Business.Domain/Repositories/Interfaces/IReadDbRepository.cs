using System;
using System.Linq;

namespace Business.Domain.Repositories.Interfaces
{
    public interface IReadDbRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity Get(Guid id);
        IQueryable<TEntity> Get();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
