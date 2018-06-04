using SonicService.ReservationService.WriteModel.Commands;
using SonicService.ReservationService.WriteModel.Domain;
using System.Collections.Generic;
using System;
using CqrsFramework.Commands;

namespace SonicService.ReservationService.WriteModel.Commands
{
    public class CreatReservationCommand : BaseCommand
    {
        public readonly List<Guid> Resources;
        public readonly Guid CustomerId;
        public readonly TimeRange TimeRange;
        public readonly Guid ReservationTypeId;

        public CreatReservationCommand(Guid id, List<Guid> resources, Guid customerId, TimeRange timeRange, Guid reservationTypeId)
        {
            Id = id;
            Resources = resources;
            CustomerId = customerId;
            TimeRange = timeRange;
            ReservationTypeId = reservationTypeId;
        }
    }
}
