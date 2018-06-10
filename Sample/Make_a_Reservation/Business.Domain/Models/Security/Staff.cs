using CqrsFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Domain.Models.ValueObjects;
using Business.Domain.Events.Security.Staffs;

namespace Business.Domain.Models.Security
{
    public class Staff : AggregateRoot, IBook2Object
    {
        public Tenant Tenant { get; set; }
        public LoginCredential LoginCredential { get; private set; }
        public PersonalInfo StaffProfile { get; private set; }
        public List<Location> LoginLocations { get; private set; }

        public Staff (){}

        public Staff(Guid id, PersonalInfo staffProfile)
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
