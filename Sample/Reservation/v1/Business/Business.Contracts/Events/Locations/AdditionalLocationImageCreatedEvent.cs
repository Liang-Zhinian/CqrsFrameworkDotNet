using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events.Locations
{
    public class AdditionalLocationImageCreatedEvent : BaseEvent, IEvent
    {
        public AdditionalLocationImageCreatedEvent(Guid id, Guid siteId, Guid locationId, byte[] image)
        {
            Id = id;
            SiteId = siteId;
            LocationId = locationId;
            Image = image;

        }

        public Guid LocationId { get; set; }
        public Guid SiteId { get; set; }
        public byte[] Image { get; set; }
    }
}
