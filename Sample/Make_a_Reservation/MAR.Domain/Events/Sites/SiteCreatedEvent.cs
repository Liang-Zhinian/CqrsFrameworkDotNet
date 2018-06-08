using System;
namespace MAR.Domain.Events.Locations
{
    public class SiteCreatedEvent : BaseEvent
    {
        public readonly string Name;
        public readonly string Description;

        public SiteCreatedEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
