using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class StaffLoginLocation
    {
        public Guid Id { get; private set; }

        public Guid StaffId { get; private set; }
        public virtual Staff Staff { get; private set; }

        public Guid LocationId { get; private set; }
        public virtual Location Location { get; private set; }

        public StaffLoginLocation(Staff staff, Location location)
        {
            Id = Guid.NewGuid();
            StaffId = staff.Id;
            LocationId = location.Id;
            Staff = staff;
            Location = location;
        }
    }
}
