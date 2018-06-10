using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Events.Security.Staffs
{
    public class StaffCreatedEvent : BaseEvent
    {
        public readonly PersonalInfo StaffProfile;

        public StaffCreatedEvent(Guid id, PersonalInfo staffProfile)
        {
            Id = id;
            StaffProfile = staffProfile;
        }
    }
}