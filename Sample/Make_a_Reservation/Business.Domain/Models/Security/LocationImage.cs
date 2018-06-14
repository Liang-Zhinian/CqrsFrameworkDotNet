using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class LocationImage : BaseObject
    {
        public string ImageUrl { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public LocationImage()
        {

        }

        public LocationImage(Guid locationId, Guid tenantId) : base(tenantId)
        {
            LocationId = locationId;
        }
    }
}
