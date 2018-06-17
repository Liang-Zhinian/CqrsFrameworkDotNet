using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaaSEqt.IdentityAccess.Domain.Models;
using CqrsFramework.Events;

namespace SaaSEqt.IdentityAccess.Domain.Events.Access
{
    public class RoleProvisioned : IEvent
    {
        public RoleProvisioned(TenantId tenantId, string name)
        {
            this.Name = name;
            this.TenantId = tenantId.Id;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string Name { get; private set; }

        public string TenantId { get; private set; }
    }
}
