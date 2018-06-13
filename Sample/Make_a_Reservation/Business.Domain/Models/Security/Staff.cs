using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Events.Security.Staffs;

namespace Business.Domain.Models.Security
{
    public class Staff : BaseObject
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public bool IsMale { get; set; }

        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public bool CanLoginAllLocations { get; set; }

        public virtual StaffLoginCredential LoginCredential { get; set; }

        public virtual StaffAddress Address { get; set; }

        public virtual StaffContact Contact { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public Staff(Guid id, string firstName, string lastName, bool isMale)
        {
            ApplyChange(new StaffCreatedEvent(id, firstName, lastName, isMale));
        }

        public void Apply(StaffCreatedEvent message)
        {
            Id = message.Id;
            FirstName = message.FirstName;
            LastName = message.LastName;
            IsMale = message.IsMale;
        }
    }
}
