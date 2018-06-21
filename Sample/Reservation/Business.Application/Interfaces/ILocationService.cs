using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface ILocationService : IDisposable
    {
        // location service
        //IEnumerable<LocationViewModel> FindLocations();
        //LocationViewModel FindLocation(Guid locationId);
        void AddLocation(LocationViewModel location);
    }
}
