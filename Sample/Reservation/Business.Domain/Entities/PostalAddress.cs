using System;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;

namespace Business.Domain.Entities
{
    public class PostalAddress: ValueObject<PostalAddress>
    {
        private PostalAddress()
        {

        }

        public PostalAddress(string streetAddress, 
                             string streetAddress2, 
                             string city, 
                             string stateProvince, 
                             string postalCode, 
                             string countryCode)
        {
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
        }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }
    }
}
