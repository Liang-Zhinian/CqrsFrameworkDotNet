using System;
using System.Collections.Generic;
using Registration.Domain.ReadModel.Security;

namespace Registration.Application.Interfaces
{
    public interface ILocationService : IDisposable
    {
        // location service
        IEnumerable<Location> FindLocations();
        Location FindLocation(Guid locationId);
    }
}
