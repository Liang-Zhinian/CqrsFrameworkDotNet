using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.IdentityAccess.Domain.Entities;
using CqrsFramework.Events;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.User
{
    public class PersonNameChanged : IEvent
    {
        public PersonNameChanged(
                TenantId tenantId,
                String username,
                FullName name)
        {
            this.Name = name;
            this.TenantId = tenantId.Id;
            this.Username = username;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public FullName Name { get; private set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
