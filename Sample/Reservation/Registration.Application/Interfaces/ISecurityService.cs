using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Domain.ReadModel.Security;

namespace Registration.Application.Interfaces
{
    public interface ISecurityService : IDisposable
    {
        void RegisterTenant(Tenant tenant, Staff administrator);
        //IEnumerable<TenantViewModel> GetAllTenants();
        Tenant GetTenantById(Guid id);
        void UpdateTenant(Tenant tenant);
        //void Remove(Guid id);
        //IList<TenantHistoryData> GetAllHistory(Guid id);

    }
}
