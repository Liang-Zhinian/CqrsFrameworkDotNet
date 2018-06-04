using System;

namespace SonicService.ReservationService.ReadModel.Dtos
{
    public class ResourceDto
    {
        public ResourceDto(Guid id, string name, Guid? resourceTypeId)
        {
            Id = id;
            Name = name;
            ResourceTypeId = resourceTypeId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ResourceTypeId { get; set; }
    }
}
