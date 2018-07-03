﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Events.Access
{
    public class GroupUnassignedFromRole : IDomainEvent
    {
        public GroupUnassignedFromRole(TenantId tenantId, string roleName, string groupName)
        {
            this.GroupName = groupName;
            this.RoleName = roleName;
            this.TenantId = tenantId;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string GroupName { get; private set; }

        public string RoleName { get; private set; }

        public TenantId TenantId { get; private set; }
    }
}