using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Business.Domain.Events.Security.Locations;

namespace Business.Domain.Models.Security
{
    public class Location : BaseObject
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual LocationContact Contact { get; set; }

        public virtual LocationAddress Address { get; set; }

        public virtual ICollection<LocationImage> AdditionalLocationImages { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public virtual ICollection<ResourceLocation> ResourceLocations { get; set; }

        public Location(Guid id, string name, string description)
        {
            ApplyChange(new LocationCreatedEvent(id, name, description));
        }

        // apply events
        public void Apply(LocationCreatedEvent message)
        {

            Id = message.Id;
            Name = message.Name;
            Description = message.Description;
        }
    }
}
