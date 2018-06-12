using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Infra.Data.ReadModel.Security
{
    public class StaffLoginLocation
    {
        [Key]
        public string Id { get; set; }

        public string StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public string LocationId { get; set; }
        public virtual Location Location { get; set; }

        public StaffLoginLocation()
        {
        }
    }
}
