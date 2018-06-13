using System;

namespace Business.Domain.Events.Security.Locations
{
    public class LocationCreatedEvent : BaseEvent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public LocationCreatedEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
