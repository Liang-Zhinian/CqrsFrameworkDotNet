using System;
namespace MAR.Domain.Events.Locations
{
    public class LocationCreatedEvent : BaseEvent
    {
        public readonly string Name;
        public readonly string Phone;
        public readonly string PhoneExtension;

        public LocationCreatedEvent(Guid id, string name, string phone, string phoneExtension)
        {
            Id = id;
            Name = name;
            Phone = phone;
            PhoneExtension = phoneExtension;
        }
    }
}
