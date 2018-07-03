using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class LocationImage
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Image { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public Guid SiteId { get; set; }
        public virtual Site Site { get; set; }

        public LocationImage()
        {
        }
    }
}
