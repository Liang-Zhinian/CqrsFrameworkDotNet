using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class LocationImage
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public LocationImage()
        {
        }
    }
}
