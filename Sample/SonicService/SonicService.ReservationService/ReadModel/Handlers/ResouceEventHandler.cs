using CqrsFramework.Events;
using CqrsFramework.Messages;
using SonicService.ReservationService.ReadModel.Dtos;
using SonicService.ReservationService.ReadModel.Events;
using SonicService.ReservationService.ReadModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonicService.ReservationService.ReadModel.Handlers
{
    public class ResouceEventHandler : IEventHandler<ResourceCreatedEvent>,
                                        IEventHandler<ResourceRenamedEvent>
    {
        public void Handle(ResourceCreatedEvent @event)
        {
            if (InMemoryDatabase.Resources.All(x => x.Id != @event.Id))
                InMemoryDatabase.Resources.Add(new ResourceDto(@event.Id,
                    @event.Name,
                    @event.ResourceTypeId));
        }

        public void Handle(ResourceRenamedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
