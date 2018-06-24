
namespace SaaSEqt.IdentityAccess.Domain.Events.Identity.User
{
    using System;
    using SaaSEqt.Common.Domain.Model;
    using SaaSEqt.IdentityAccess.Domain.Entities;
    using CqrsFramework.Events;

    public class PersonContactInformationChanged : IEvent
    {
        public PersonContactInformationChanged(
                TenantId tenantId,
                String username,
                ContactInformation contactInformation)
        {
            this.ContactInformation = contactInformation;
            this.TenantId = tenantId.Id;
            this.Username = username;

            this.Id = Guid.NewGuid();
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public ContactInformation ContactInformation { get; private set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
