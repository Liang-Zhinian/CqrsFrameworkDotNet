using System;
using System.Linq;
using DomainModels = SaaSEqt.IdentityAccess.Domain.Entities;
using SaaSEqt.IdentityAccess.Domain.Repositories;
using SaaSEqt.IdentityAccess.Infra.Data.Context;
//using ReadModels = SaaSEqt.IdentityAccess.Infra.Data.Models;

namespace SaaSEqt.IdentityAccess.Infra.Data.Repositories
{
    public class TenantRepository : DomainRepository<DomainModels.Tenant>, ITenantRepository
    {
        public TenantRepository(IdentityAccessDbContext context):base(context){}

        public void Add(DomainModels.Tenant tenant)
        {
            //ReadModels.Tenant t = new ReadModels.Tenant();
            //t.Id = Guid.Parse(tenant.TenantId.Id);
            //t.Name = tenant.Name;
            //t.Description = tenant.Description;
            //t.Active = tenant.Active;
            base.Add(tenant);
            base.SaveChanges();
        }

        public DomainModels.Tenant Get(DomainModels.TenantId tenantId)
        {
            var tenant = this.Find(Guid.Parse(tenantId.Id));
            return tenant;
            //return new DomainModels.Tenant(
            //    new DomainModels.TenantId(tenant.Id.ToString()),
            //    tenant.Name, 
            //    tenant.Description, 
            //    tenant.Active
            //);
        }

        public DomainModels.Tenant GetByName(string name)
        {
            var tenant = this.Find(_=>_.Name.Equals(name)).First();
            return tenant;
            //return new DomainModels.Tenant(
            //    new DomainModels.TenantId(tenant.Id.ToString()),
            //    tenant.Name,
            //    tenant.Description,
            //    tenant.Active
            //);
        }

        public DomainModels.TenantId GetNextIdentity()
        {
            return new DomainModels.TenantId(Guid.NewGuid().ToString());
        }

        public void Register(DomainModels.Tenant tenant)
        {
            base.Add(tenant);
            base.SaveChanges();
        }

        public void Remove(DomainModels.Tenant tenant)
        {
            //var t = this.Find(Guid.Parse(tenant.TenantId.Id));
            //tenant.Deactivate();
            base.Update(tenant);
            base.SaveChanges();
        }
    }
}
