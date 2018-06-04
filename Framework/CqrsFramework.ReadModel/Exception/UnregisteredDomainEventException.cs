using System;

namespace CqrsFramework.ReadModel.Exception
{
    public class UnregisteredDomainEventException : System.Exception
    {
        public UnregisteredDomainEventException(string message) : base(message) { }
    }
}
