using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CqrsFramework.Events;
using SaaSEqt.IdentityAccess.Domain.Models;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.Tenant
{
    public class TenantProvisioned : IEvent
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
