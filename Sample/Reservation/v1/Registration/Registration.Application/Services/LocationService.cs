using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Registration.Domain.Repositories.Interfaces;
using Registration.Domain.ReadModel;
using CqrsFramework.Domain;
using System.Linq;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;

namespace Registration.Application.Services
{
    public class LocationService : ILocationService
    {
        //private readonly ISession _session;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(
            //ISession session, 
                             IMapper mapper,
                          ILocationRepository locationRepository
                              )
        {
            //_session = session;
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Location FindLocation(Guid locationId)
        {
            var location = _locationRepository.Find(locationId);

            return location;
        }

        public IEnumerable<Location> FindLocations()
        {
            var locations = _locationRepository.Find(_ => true).Include(_=>_.AdditionalLocationImages);
            return locations;

        }

    }
}
