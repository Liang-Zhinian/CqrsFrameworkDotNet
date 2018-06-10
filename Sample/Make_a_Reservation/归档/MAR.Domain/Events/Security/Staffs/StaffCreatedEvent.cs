using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Events.Security.Staffs
{
    public class StaffCreatedEvent : BaseEvent
    {
        public readonly Profile StaffProfile;

        public StaffCreatedEvent(Guid id, Profile staffProfile)
        {
            Id = id;
            StaffProfile = staffProfile;
        }
    }
}