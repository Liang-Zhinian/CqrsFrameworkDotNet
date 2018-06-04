using SonicService.ReservationService.WriteModel.Domain;
using System;
using System.Collections.Generic;

namespace SonicService.ReservationService.ReadModel.Dtos
{
    public class ReservationDto
    {
        public ReservationDto(Guid id, Guid customerId, IList<Guid> resouces, TimeRange timeRange)
        {
            Id = id;
            CustomerId = customerId;
            Resources = resouces;
            StartTime = timeRange.Date.ToString("yyyy-MM-dd")+" "+timeRange.StartTime;
            EndTime = timeRange.Date.ToString("yyyy-MM-dd") + " " + timeRange.EndTime;
        }

        public Guid Id { get; set; }

        public IList<Guid> Resources { get; set; }

        public Guid CustomerId { get; set; }
        
        //public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        //public string TypeOfReservation { get; set; }
    }
}
