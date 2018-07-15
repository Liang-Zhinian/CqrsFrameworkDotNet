using System;
using System.Collections.Generic;
using Registration.Domain.ReadModel.Security;

namespace Registration.Infrastructure.Repositories
{
    public static class InMemoryDatabase
    {
        public static readonly List<Tenant> Tenants = new List<Tenant>();
    }
}
