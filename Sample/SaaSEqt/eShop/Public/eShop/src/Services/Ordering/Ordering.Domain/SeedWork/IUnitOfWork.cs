﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace SaaSEqt.eShop.Services.Ordering.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
