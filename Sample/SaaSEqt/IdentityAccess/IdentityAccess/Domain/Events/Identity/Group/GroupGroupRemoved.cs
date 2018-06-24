using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.IdentityAccess.Domain.Entities;
using CqrsFramework.Events;

namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.Group
{
    public class GroupGroupRemoved : IEvent
    {
        public GroupGroupRemoved(TenantId tenantId, string groupName, string nestedGroupName)
        {
            this.GroupName = groupName;
            this.NestedGroupName = nestedGroupName;
            this.TenantId = tenantId.Id;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }


        public string GroupName { get; private set; }

        public string NestedGroupName { get; private set; }

        public string TenantId { get; private set; }
    }

}
