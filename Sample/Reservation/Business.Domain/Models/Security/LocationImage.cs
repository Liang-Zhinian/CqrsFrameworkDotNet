using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class LocationImage
    {
        public Guid Id { get; private set; }
        public string Image { get; private set; }

        public Guid LocationId { get; private set; }
        public virtual Location Location { get; private set; }

        public LocationImage(Guid locationId, Guid tenantId, string image)
        {
            Id = GuidUtil.NewSequentialId();
            LocationId = locationId;
            Image = image;
        }
    }
}
