using System;
using System.Collections.Generic;
using System.Text;
using CqrsFramework.Bus;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using SonicService.ReservationService.ReadModel.Events;

namespace SonicService.ReservationService.Api.Tests
{
    public class WhenCreateReservation : TestBase
    {
        readonly Guid _reservationId = Guid.NewGuid();

        public override Dictionary<Guid, List<IEvent>> GivenTheseEvents()
        {
            return new Dictionary<object, List<object>>
            {
                {_reservationId, new List<object>
                    {
                        new ReservationCreatedEvent(_reservationId, "John", "abc@example.com", 500),
                        
                    }
                }
            };
        }

        public override void RegisterHandler(InProcessBus bus, IRepository repo)
        {
            throw new NotImplementedException();
        }

        public override object WhenThisHappens()
        {
            throw new NotImplementedException();
        }
    }
}
