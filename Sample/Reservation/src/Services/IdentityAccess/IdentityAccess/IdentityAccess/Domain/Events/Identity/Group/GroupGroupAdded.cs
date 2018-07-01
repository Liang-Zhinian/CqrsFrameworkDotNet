
namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.Group
{
    using System;
    using SaaSEqt.Common.Domain.Model;
    using SaaSEqt.IdentityAccess.Domain.Entities;

    public class GroupGroupAdded : IDomainEvent
    {
        public GroupGroupAdded(TenantId tenantId, string groupName, string nestedGroupName)
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
