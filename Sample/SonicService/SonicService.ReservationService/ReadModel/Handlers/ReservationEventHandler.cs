using CqrsFramework.Events;
using SonicService.ReservationService.ReadModel.Events;
using System;
using System.Collections.Generic;
using SonicService.ReservationService.ReadModel.Dtos;
using System.Linq;
using SonicService.ReservationService.ReadModel.Infrastructure;

namespace SonicService.ReservationService.ReadModel.Handlers
{
    public class ReservationEventHandler : IEventHandler<ReservationCreatedEvent>
    {
        //private List<ReservationDto> _reservations = new List<ReservationDto>();

        public void Handle(ReservationCreatedEvent @event)
        {
            if (InMemoryDatabase.Reservations.All(x => x.Id != @event.Id))
                InMemoryDatabase.Reservations.Add(new ReservationDto(@event.Id,
                    @event.CustomerId,
                    @event.Resources,
                    @event.TimeRange));
        }
    }
}
