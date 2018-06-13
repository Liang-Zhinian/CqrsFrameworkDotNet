using System;

namespace Business.Domain.Events.Security.Businesses
{
    public class TenantCreatedEvent : BaseEvent
    {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }

        public TenantCreatedEvent(Guid id, string name, string displayName)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
        }
    }
}
