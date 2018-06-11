using System;
using System.Linq;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Registration.Infra.Data.Repositories
{
    public class ReadDbRepository<TEntity> : IReadDbRepository<TEntity> where TEntity : class
    {
        protected readonly ReservationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public ReadDbRepository(ReservationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
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
    }
}
