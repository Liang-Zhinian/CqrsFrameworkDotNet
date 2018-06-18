using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class StaffLoginLocation : BaseObject
    {
        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public StaffLoginLocation()
        {

        }

        public StaffLoginLocation(Guid staffId, Guid locationId, Guid tenantId) : base(tenantId)
        {
            StaffId = staffId;
            LocationId = locationId;
        }
    }
}
