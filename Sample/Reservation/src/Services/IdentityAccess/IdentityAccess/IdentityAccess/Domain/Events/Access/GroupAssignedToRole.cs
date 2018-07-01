
namespace SaaSEqt.IdentityAccess.Domain.Events.Access
{
    using System;
    using SaaSEqt.Common.Domain.Model;
    using SaaSEqt.IdentityAccess.Domain.Entities;

    public class GroupAssignedToRole : IDomainEvent
    {
        public GroupAssignedToRole(TenantId tenantId, string roleName, string groupName)
        {
            this.GroupName = groupName;
            this.RoleName = roleName;
            this.TenantId = tenantId;
            this.Id = Guid.NewGuid();
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string GroupName { get; private set; }

        public string RoleName { get; private set; }

        public TenantId TenantId;
    }
}
