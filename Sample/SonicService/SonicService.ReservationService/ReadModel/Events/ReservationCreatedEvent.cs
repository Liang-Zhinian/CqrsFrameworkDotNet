using CqrsFramework.Events;
using SonicService.ReservationService.ReadModel.Events;
using SonicService.ReservationService.WriteModel.Domain;
using System;
using System.Collections.Generic;

namespace SonicService.ReservationService.ReadModel.Events
{
    public class ReservationCreatedEvent : BaseEvent
    {
        public readonly IList<Guid> Resources;
        public readonly Guid CustomerId;
        public readonly TimeRange TimeRange;
        public readonly Guid ReservationTypeId;

        public ReservationCreatedEvent(Guid id, IList<Guid> resources, Guid customerId, TimeRange timeRange, Guid reservationTypeId)
        {
            Id = id;
            Resources = resources;
            CustomerId = customerId;
            TimeRange = timeRange;
            ReservationTypeId = reservationTypeId;
        }
    }
}
