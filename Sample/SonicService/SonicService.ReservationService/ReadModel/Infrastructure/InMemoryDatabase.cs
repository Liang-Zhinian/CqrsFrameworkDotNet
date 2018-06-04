using SonicService.ReservationService.ReadModel.Dtos;
using System;
using System.Collections.Generic;

namespace SonicService.ReservationService.ReadModel.Infrastructure
{
    public static class InMemoryDatabase
    {
        public static readonly Dictionary<Guid, ReservationDto> Details = new Dictionary<Guid, ReservationDto>();
        public static readonly List<ReservationDto> Reservations = new List<ReservationDto>();
        public static readonly List<ResourceDto> Resources = new List<ResourceDto>();
    }
}
