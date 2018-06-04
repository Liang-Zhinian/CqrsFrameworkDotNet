using SonicService.ReservationService.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace SonicService.ReservationService.ReadModel
{
    public interface IReadModelFacade
    {
        IEnumerable<ReservationDto> GetAllReservations();
        IEnumerable<ResourceDto> GetAllResources();
    }
}
