using CqrsFramework.Domain;
using System;
using System.Collections.Generic;

namespace MAR.Domain.Models
{
    public class Reservation : AggregateRoot
    {
        // public DateTime DateCreated;
        // public DateTime LastModified;
        // public string LastActionBy;
        // public string EmployeeCreated;
        private readonly Guid _reservationId;
        private readonly Client _client;
        private readonly Employee _employee;    
        private readonly DateTime _startTime;
        private readonly DateTime _endTimeExpected;
        private readonly DateTime _endTime;
        private readonly float _priceExpected;
        private readonly float _priceFull;
        private readonly float _discount;
        private readonly float _priceFinal;
        private readonly ReservationStatus _reservationStatus;
        private readonly Business _business;
        private readonly string _title;
        private readonly string _description;
        private readonly ReservationType _reservationType;
        private readonly List<Resource> _resources;

        public Reservation(Guid id, Guid reservationId)
        {
            Id = id;
            _reservationId = reservationId;

            // ApplyChange(new ReservationCreatedEvent(id, resources, customerId, timeRange, reservationTypeId));
        }

        private Reservation()
        {

        }
    }
}
