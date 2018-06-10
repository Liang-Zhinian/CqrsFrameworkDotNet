using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface ITenantAppService : IDisposable
    {
        void Register(TenantViewModel tenantViewModel);
        IEnumerable<TenantViewModel> GetAll();
        TenantViewModel GetById(Guid id);
        void Update(TenantViewModel tenantViewModel);
        void Remove(Guid id);
        IList<TenantHistoryData> GetAllHistory(Guid id);
    }
}
