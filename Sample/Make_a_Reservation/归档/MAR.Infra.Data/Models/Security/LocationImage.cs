using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models.Security
{
    public class LocationImage
    {
        [Key]
        public string Id { get; set; }
        public string ImageURL { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

        public LocationImage()
        {
        }
    }
}
