using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models.Security
{
    public class BusinessAddress
    {
        [Key]
        public string Id { get; set; }
        /// Street
        public string Street { get; set; }
        /// Additional street information
        public string Street2 { get; set; }
        /// City
        public string City { get; set; }
        /// State
        public string State { get; set; }
        /// Country
        public string Country { get; set; }
        /// Postal code / zip code
        public string PostalCode { get; set; }
        /// Zip code
        public string ForeignZip { get; set; }

        public string BusinessId { get; set; }
        public Business Business { get; set; }

        public BusinessAddress()
        {
        }
    }
}
