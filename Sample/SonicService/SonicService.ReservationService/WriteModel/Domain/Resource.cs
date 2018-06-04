using CqrsFramework.Domain;
using SonicService.ReservationService.ReadModel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicService.ReservationService.WriteModel.Domain
{
    public class Resource : AggregateRoot
    {
        private readonly string _name;

        private readonly Guid? _resourceTypeId;

        private Resource() { }

        public Resource(Guid id, string name, Guid? resourceTypeId)
        {
            Id = id;
            ApplyChange(new ResourceCreatedEvent(id, name, resourceTypeId));
        }

        internal void ChangeName(string newName)
        {
            ApplyChange(new ResourceRenamedEvent(Id, newName));
        }
    }
}
