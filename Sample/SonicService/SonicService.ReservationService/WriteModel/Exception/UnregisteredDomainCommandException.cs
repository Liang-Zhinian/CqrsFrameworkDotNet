using System;

namespace SonicService.ReservationService.WriteModel.Exception
{
    public class UnregisteredDomainCommandException : System.Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message) { }
    }
}
