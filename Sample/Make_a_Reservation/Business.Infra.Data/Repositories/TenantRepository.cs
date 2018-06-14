using System;
using System.Linq;
using Business.Domain.Models.Security;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class TenantRepository : DomainRepository<Tenant>, ITenantRepository
    {
        public TenantRepository(BusinessDbContext context):base(context){}

        public void Register(Tenant tenant)
        {
            this.Add(tenant);
            this.SaveChanges();
        }
    }
}
