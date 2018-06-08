using System;
namespace MAR.Domain.Models.Locations
{
    public class LocationImage
    {
        public Guid LocationId { get; private set; }
        public Guid ImageId { get; private set; }
        public string ImageUrl { get; private set; }

        public LocationImage()
        {
        }

        public LocationImage(Guid locationId, Guid imageId, string imageUrl)
        {
            LocationId = locationId;
            ImageId = imageId;
            ImageUrl = imageUrl;
        }
    }
}
