using System;
using SonicService.ReservationService.ReadModel.Events;
using SonicService.ReservationService.WriteModel.Commands;
using SonicService.ReservationService.WriteModel.Domain;
using SonicService.ReservationService.WriteModel.Handlers;
using CqrsFramework.Events;
using CqrsFramework.Tests.Extensions.TestHelpers;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace SonicService.ReservationService.Tests
{
    public class WhenReservationCreated : Specification<Reservation, ReservationCommandHandler, CreatReservationCommand>
    {
        private Guid _id;
        protected override ReservationCommandHandler BuildHandler()
        {
            return new ReservationCommandHandler(Session);
        }

        protected override IEnumerable<IEvent> Given()
        {
            _id = Guid.NewGuid();
            //Guid customerId = Guid.Parse("71DFCD1D-AC1E-4CAE-9998-C747662DBF0E");
            //Guid roomId = Guid.Parse("2150E333-8FDC-42A3-9474-1A3956D46DE8");
            //List<Guid> reservableList = new List<Guid>();
            //reservableList.Add(roomId);
            // TimeRange timeRange = new TimeRange();
            return new List<IEvent>();// { new ReservationCreatedEvent(_id, reservableList, customerId, timeRange) { Version = 1 }/*, new ItemsCheckedInToInventory(_guid, 2) { Version = 2 } */};
        }

        protected override CreatReservationCommand When()
        {
            Guid customerId = Guid.Parse("71DFCD1D-AC1E-4CAE-9998-C747662DBF0E");
            Guid roomId = Guid.Parse("2150E333-8FDC-42A3-9474-1A3956D46DE8");
            List<Guid> reservableList = new List<Guid>();
            TimeRange timeRange = new TimeRange();
            return new CreatReservationCommand(_id, reservableList, customerId, timeRange);
        }

        [Then]
        public void Should_create_one_event()
        {
            Assert.Equal(1, PublishedEvents.Count);
        }

        [Then]
        public void Should_create_correct_event()
        {
            Assert.IsType<ReservationCreatedEvent>(PublishedEvents.First());
        }

        [Then]
        public void Should_save_name()
        {
            Assert.Equal(Guid.Parse("71DFCD1D-AC1E-4CAE-9998-C747662DBF0E"), ((ReservationCreatedEvent)PublishedEvents.First()).CustomerId);
        }
    }
}
