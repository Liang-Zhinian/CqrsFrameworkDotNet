using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Utils;

namespace Business.Domain.Entities
{
    public class LocationImage
    {
        public Guid Id { get; private set; }
        public byte[] Image { get; private set; }

        public Guid LocationId { get; private set; }
        public virtual Location Location { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public LocationImage(Guid siteId, Guid locationId, byte[] image)
        {
            Id = GuidUtil.NewSequentialId();
            LocationId = locationId;
            Image = image;

            SiteId = siteId;
        }
    }
}
