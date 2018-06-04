using SonicService.ReservationService.ReadModel.Infrastructure;
using System;
using System.Collections.Generic;
using SonicService.ReservationService.ReadModel.Dtos;

namespace SonicService.ReservationService.ReadModel
{
    public class ReadModelFacade : IReadModelFacade
    {
        public ReadModelFacade()
        {

        }
        public IEnumerable<ReservationDto> GetAllReservations()
        {
            return InMemoryDatabase.Reservations;
        }

        public IEnumerable<ResourceDto> GetAllResources()
        {
            return InMemoryDatabase.Resources;
        }
    }
}
