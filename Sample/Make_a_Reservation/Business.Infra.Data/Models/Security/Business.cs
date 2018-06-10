using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAR.Infra.Data.Models.Security
{
    public class Business
    {
        [Key]
        public string Id { get; set; }
        public const string DEFAULT_NAME = "default";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public BusinessContact Contact { get; set; }
        public BusinessAddress Address { get; set; }
        public Branding Branding { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
