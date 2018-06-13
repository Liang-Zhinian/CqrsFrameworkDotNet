using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class LocationImage : BaseObject
    {
        public Guid ImageId { get; set; }
        public virtual Image Image { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
