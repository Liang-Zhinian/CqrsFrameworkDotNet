﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Business.Domain.UoW;

namespace Business.Domain.Repositories
{
    public interface IDomainRepository<TEntity> : IDisposable where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Guid id);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);
        //int SaveChanges();
    }
}
