using System;
using CqrsFramework.Domain;

namespace Business.Domain.Entities
{
    public class Geolocation: ValueObject<Geolocation>
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        private Geolocation()
        {

        }

        public Geolocation(double? latitude, double? longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
