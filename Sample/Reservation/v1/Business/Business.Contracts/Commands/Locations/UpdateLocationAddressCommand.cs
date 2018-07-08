using System;
namespace Business.Contracts.Commands.Locations
{
    public class UpdateLocationAddressCommand
    {
        public UpdateLocationAddressCommand()
        {
        }

        public Guid LocationId { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
