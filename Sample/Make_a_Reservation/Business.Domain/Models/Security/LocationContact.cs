using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class LocationContact : BaseObject
    {
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
