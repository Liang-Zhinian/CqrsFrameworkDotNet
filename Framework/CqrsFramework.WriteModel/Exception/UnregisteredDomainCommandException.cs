using System;

namespace CqrsFramework.WriteModel.Exception
{
    public class UnregisteredDomainCommandException : System.Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message) { }
    }
}
