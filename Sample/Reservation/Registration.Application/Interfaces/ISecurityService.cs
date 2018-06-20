using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Application.ViewModels;

namespace Registration.Application.Interfaces
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
