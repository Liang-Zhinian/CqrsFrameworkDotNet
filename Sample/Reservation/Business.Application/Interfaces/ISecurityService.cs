using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface ISecurityService : IDisposable
    {
        void RegisterTenant(TenantViewModel tenantViewModel, StaffViewModel administratorViewModel);
        //IEnumerable<TenantViewModel> GetAllTenants();
        TenantViewModel GetTenantById(Guid id);
        void UpdateTenant(TenantViewModel tenantViewModel);
        //void Remove(Guid id);
        //IList<TenantHistoryData> GetAllHistory(Guid id);

    }
}
