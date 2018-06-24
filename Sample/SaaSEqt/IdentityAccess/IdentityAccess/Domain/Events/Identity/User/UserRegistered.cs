using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.IdentityAccess.Domain.Entities;
using CqrsFramework.Events;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.User
{
    public class UserRegistered : IEvent
    {
        public UserRegistered(
                TenantId tenantId,
                String username,
                FullName name,
                EmailAddress emailAddress)
        {
            this.EmailAddress = emailAddress;
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

        public EmailAddress EmailAddress { get; private set; }

        public FullName Name { get; private set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
