﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Access.Entities;
using SaaSEqt.IdentityAccess.Domain.Identity.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Access.Events
{
    public class UserUnassignedFromRole : IDomainEvent
    {
        public UserUnassignedFromRole(TenantId tenantId, string roleName, string username)
        {
            this.RoleName = roleName;
            this.TenantId = tenantId;
            this.Username = username;

            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }


        public string Username { get; private set; }

        public string RoleName { get; private set; }

        public TenantId TenantId { get; private set; }
    }
}
