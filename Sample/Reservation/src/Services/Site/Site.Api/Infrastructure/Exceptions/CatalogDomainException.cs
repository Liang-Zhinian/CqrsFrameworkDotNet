using System;

namespace SaaSEqt.eShop.Site.Api.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class SiteDomainException : Exception
    {
        public SiteDomainException()
        { }

        public SiteDomainException(string message)
            : base(message)
        { }

        public SiteDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
