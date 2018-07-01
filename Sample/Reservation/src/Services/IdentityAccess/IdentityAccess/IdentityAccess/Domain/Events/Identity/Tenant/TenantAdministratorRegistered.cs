
namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.Tenant
{
    using System;
    using SaaSEqt.Common.Domain.Model;
    using SaaSEqt.IdentityAccess.Domain.Entities;

    public class TenantAdministratorRegistered : IDomainEvent
    {
        public TenantAdministratorRegistered(
            TenantId tenantId,
            string name,
            FullName administorName,
            EmailAddress emailAddress,
            string username,
            string temporaryPassword)
        {
            this.AdministorName = administorName;
            this.Name = name;
            this.TemporaryPassword = temporaryPassword;
            this.TenantId = tenantId.Id;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public FullName AdministorName { get; private set; }

        public string Name { get; private set; }

        public string TemporaryPassword { get; private set; }

        public string TenantId { get; private set; }
    }
}
