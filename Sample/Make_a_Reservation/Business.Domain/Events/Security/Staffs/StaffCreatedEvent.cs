using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Events.Security.Staffs
{
    public class StaffCreatedEvent : BaseEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }

        public StaffCreatedEvent(Guid id, string firstName, string lastName, bool isMale)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsMale = isMale;
        }
    }
}