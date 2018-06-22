using System;
using Business.Domain.Models.Security;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Models
{
    public class ResourceLocation
    {
        public ResourceLocation(Resource resource, Location location)
        {
            Id = Guid.NewGuid();
            ResourceId = resource.Id;
            LocationId = location.Id;
        }

        public Guid Id { get; private set; }

        public Guid ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public TenantId TenantId { get; private set; }

    }
}
