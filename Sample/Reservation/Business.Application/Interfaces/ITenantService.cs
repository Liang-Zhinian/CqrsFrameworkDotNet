using System;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface ITenantService
    {
        void ProvisionTenant(TenantViewModel tenant, StaffViewModel administrator);
    }
}
