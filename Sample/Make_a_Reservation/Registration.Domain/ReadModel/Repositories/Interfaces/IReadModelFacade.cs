using System;
using System.Collections.Generic;
using Registration.Domain.ReadModel.Security;

namespace Registration.Domain.Repositories.Interfaces
{
    public interface IReadModelFacade
    {
        IEnumerable<Tenant> GetAllTenants();
        void CreateTenant(Tenant tenant);
    }
}
