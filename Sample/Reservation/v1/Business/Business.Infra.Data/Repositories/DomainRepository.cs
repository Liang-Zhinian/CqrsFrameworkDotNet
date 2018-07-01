using System;
using System.Linq;
using System.Linq.Expressions;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Business.Infra.Data.Repositories
{
    public class DomainRepository<TEntity> : IDomainRepository<TEntity> where TEntity : class
    {
        protected readonly BusinessDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public DomainRepository(BusinessDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where<TEntity>(predicate);
        }

        public TEntity Find(Guid id)
        {
            return DbSet.Find(id);
        }
    }
}
