using System;
using System.Collections.Generic;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Infrastructure.Repositories
{
    public class ReadModelFacade : IReadModelFacade
    {
        public ReadModelFacade()
        {

        }

        public void CreateTenant(Tenant tenant)
        {
            InMemoryDatabase.Tenants.Add(tenant);
        }

        public IEnumerable<Tenant> GetAllTenants()
        {
            return InMemoryDatabase.Tenants;
        }
    }
}
