using System;
using CqrsFramework.Domain;

namespace SaaSEqt.eShop.Site.Api.Model
{
    public class Geolocation
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
