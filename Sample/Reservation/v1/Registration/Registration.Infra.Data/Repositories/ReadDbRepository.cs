﻿using System;
using System.Linq;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Registration.Infrastructure.Repositories
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

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where<TEntity>(predicate);
        }

        public TEntity Find(Guid id)
        {
            return DbSet.Find(id);
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
