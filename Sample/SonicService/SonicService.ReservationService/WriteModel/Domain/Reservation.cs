using CqrsFramework.Domain;
using SonicService.ReservationService.ReadModel.Events;
using System;
using System.Collections.Generic;

namespace SonicService.ReservationService.WriteModel.Domain
{
    public class Reservation : AggregateRoot
    {
        private readonly Guid _reservationTypeId;
        private readonly Guid _customerId;
        private readonly TimeRange _timeRange;
        private readonly IList<Guid> _resources;

        public Reservation(Guid id, IList<Guid> resources, Guid customerId, TimeRange timeRange, Guid reservationTypeId)
        {
            Id = id;
            _customerId = customerId;
            _timeRange = timeRange;
            _resources = resources;
            _reservationTypeId = reservationTypeId;

            ApplyChange(new ReservationCreatedEvent(id, resources, customerId, timeRange, reservationTypeId));
        }

        private Reservation()
        {

        }
    }
}
