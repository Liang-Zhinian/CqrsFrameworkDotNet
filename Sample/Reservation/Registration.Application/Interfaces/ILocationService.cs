using System;
using System.Collections.Generic;
//using Registration.Application.EventSourcedNormalizers;
using Registration.Application.ViewModels;

namespace Registration.Application.Interfaces
{
    public interface ILocationService : IDisposable
    {
        // location service
        IEnumerable<LocationViewModel> FindLocations();
        LocationViewModel FindLocation(Guid locationId);
        void AddLocation(LocationViewModel location);
    }
}
