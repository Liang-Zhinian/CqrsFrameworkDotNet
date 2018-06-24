using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.IdentityAccess.Domain.Entities;
using CqrsFramework.Events;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.User
{
    public class UserEnablementChanged : IEvent
    {
        public UserEnablementChanged(
                TenantId tenantId,
                String username,
                Enablement enablement)
        {
            this.Enablement = enablement;
            this.TenantId = tenantId.Id;
            this.Username = username;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public Enablement Enablement { get; private set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
