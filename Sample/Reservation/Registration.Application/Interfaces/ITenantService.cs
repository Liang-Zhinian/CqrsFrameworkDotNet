using System;
using System.Collections.Generic;
using Registration.Application.ViewModels;

namespace Registration.Application.Interfaces
{
    public interface ITenantService
    {
        IEnumerable<TenantViewModel> GetTenants();
        //TenantViewModel GetTenantById(Guid id);
    }
}
