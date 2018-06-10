using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models.Security
{
    public class LocationContact
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

        public LocationContact()
        {
        }
    }
}
