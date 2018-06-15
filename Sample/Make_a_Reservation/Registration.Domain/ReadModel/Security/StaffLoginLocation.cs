using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class StaffLoginLocation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public StaffLoginLocation()
        {
        }
    }
}
