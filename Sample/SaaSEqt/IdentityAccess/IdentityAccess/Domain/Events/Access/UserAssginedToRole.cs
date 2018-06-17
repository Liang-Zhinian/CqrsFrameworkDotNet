using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaaSEqt.IdentityAccess.Domain.Models;
using CqrsFramework.Events;

namespace SaaSEqt.IdentityAccess.Domain.Events.Access
{
    public class UserAssignedToRole : IEvent
    {
        public UserAssignedToRole(
            TenantId tenantId,
            string roleName,
            string username,
            string firstName,
            string lastName,
            string emailAddress)
        {
            this.EmailAddress = emailAddress;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoleName = roleName;
            this.TenantId = tenantId;
            this.Username = username;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string EmailAddress { get; private set; }


        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string RoleName { get; private set; }

        public TenantId TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
