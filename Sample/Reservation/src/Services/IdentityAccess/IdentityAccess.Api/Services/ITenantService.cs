using System;
using IdentityAccess.Api.ViewModel;

namespace IdentityAccess.Api.Services
{
    public interface ITenantService
    {
        void ProvisionTenant(TenantViewModel tenant, StaffViewModel administrator);
        //void ModifyTenantAddress(TenantAddressViewModel addressViewModel);
        //void AddTenantAddress(TenantAddressViewModel addressViewModel);
    }
}
