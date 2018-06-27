using System;
namespace Business.WebApi.Requests.Locations
{
    public class SetLocationGeolocationRequest
    {
        public Guid Id { get; set; }

        public Guid SiteId { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
