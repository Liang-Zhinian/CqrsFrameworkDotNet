using CqrsFramework.Domain;
// using MAR.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain
{
    public class Resource : AggregateRoot
    {
        private readonly Guid _reservationId;
        private readonly string _name;
        private readonly string _description;
        private readonly ResourceType _resourceType;
        private readonly ResourceStatus _resourceStatus;

        private Resource() { }

        public Resource(Guid id, Guid reservationId, string name, string description, ResourceType resourceType)
        {
            Id = id;
            _name = name;
            _description = description;
            _reservationId = reservationId;
            _resourceType = resourceType;

            // ApplyChange(new ResourceCreatedEvent(id, name, resourceTypeId));
        }

        internal void ChangeName(string newName)
        {
            // ApplyChange(new ResourceRenamedEvent(Id, newName));
        }
    }
}
