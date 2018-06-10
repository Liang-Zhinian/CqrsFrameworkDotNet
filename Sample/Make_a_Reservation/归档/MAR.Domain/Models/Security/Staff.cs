using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using MAR.Domain.Models.ValueObjects;
using MAR.Domain.Events.Security.Staffs;

namespace MAR.Domain.Models.Security
{
    public class Staff : AggregateRoot, IBook2Object
    {
        public Business Business { get; set; }
        public LoginCredential LoginCredential { get; private set; }
        public Profile StaffProfile { get; private set; }
        public List<Location> LoginLocations { get; private set; }

        public Staff (){}

        public Staff(Guid id, Profile staffProfile)
        {
            ApplyChange(new StaffCreatedEvent(id, staffProfile));
        }

        public void Apply(StaffCreatedEvent message)
        {
            Id = message.Id;
            StaffProfile = message.StaffProfile;
        }
    }
}
