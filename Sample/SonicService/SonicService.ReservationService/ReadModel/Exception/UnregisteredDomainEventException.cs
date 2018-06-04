using System;

namespace SonicService.ReservationService.ReadModel.Exception
{
    public class UnregisteredDomainEventException : System.Exception
    {
        public UnregisteredDomainEventException(string message) : base(message) { }
    }
}
