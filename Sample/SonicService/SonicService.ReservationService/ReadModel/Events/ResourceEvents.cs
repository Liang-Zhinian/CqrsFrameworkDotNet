using System;
using System.Collections.Generic;
using System.Text;

namespace SonicService.ReservationService.ReadModel.Events
{
    public class ResourceCreatedEvent : BaseEvent
    {
        public readonly string Name;
        public readonly Guid? ResourceTypeId;

        public ResourceCreatedEvent(Guid id, string name, Guid? resourceTypeId)
        {
            Id = id;
            Name = name;
            ResourceTypeId = resourceTypeId;
        }
    }

    public class ResourceRenamedEvent : BaseEvent {
        public readonly string NewName;

        public ResourceRenamedEvent(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}
