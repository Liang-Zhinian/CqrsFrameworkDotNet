﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Model.Access.Entities;
using SaaSEqt.IdentityAccess.Domain.Model.Identity.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Model.Access.Events
{
    public class UserAssignedToRole : IDomainEvent
    {
        public UserAssignedToRole(
            Guid tenantId,
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

            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string EmailAddress { get; private set; }


        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string RoleName { get; private set; }

        public Guid TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
