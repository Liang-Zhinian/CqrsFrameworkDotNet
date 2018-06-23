using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models
{
    public class Geolocation: ValueObject<Geolocation>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Geolocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
