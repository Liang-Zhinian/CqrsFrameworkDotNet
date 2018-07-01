using System;
using CqrsFramework.Events;

namespace SaaSEqt.eShop.Site.Api.Events.Sites
{
    public class SiteCreatedEvent : SiteEvent, IEvent
    {
        public SiteCreatedEvent(Guid id, string name, string description, bool active, string tenantId)
        {
            this.Id = id;
            this.Version = 1;
            this.TimeStamp = DateTimeOffset.Now;
            this.Name = name;
            this.Description = description;
            this.TenantId = tenantId;
        }
    }
}
