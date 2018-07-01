using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.Tenant
{
    public class TenantProvisioned : IDomainEvent
    {
        public TenantProvisioned(TenantId tenantId)
        {
            this.TenantId = tenantId.Id;
            this.Id = Guid.NewGuid();
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }
        
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string TenantId { get; private set; }
    }
}
