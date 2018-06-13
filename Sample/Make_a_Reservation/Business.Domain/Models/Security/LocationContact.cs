using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class LocationContact : BaseObject
    {
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
