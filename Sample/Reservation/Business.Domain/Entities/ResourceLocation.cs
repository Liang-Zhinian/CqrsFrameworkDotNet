using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Entities
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

    }
}
