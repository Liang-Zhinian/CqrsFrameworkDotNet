using System;
using Business.Domain.Models.Security;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Models
{
    public class ResourceLocation : BaseObject
    {
        public Guid ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

    }
}
