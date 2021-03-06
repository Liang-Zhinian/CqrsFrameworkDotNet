﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Domain.Identity.Entities;

namespace SaaSEqt.IdentityAccess.Domain.Identity.Events.Group
{
    public class GroupGroupRemoved : IDomainEvent
    {
        public GroupGroupRemoved(TenantId tenantId, string groupName, string nestedGroupName)
        {
            this.GroupName = groupName;
            this.NestedGroupName = nestedGroupName;
            this.TenantId = tenantId.Id;

            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }


        public string GroupName { get; private set; }

        public string NestedGroupName { get; private set; }

        public string TenantId { get; private set; }
    }

}
