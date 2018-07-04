using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Events.Locations;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Domain.Services;

using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace Business.Application.Services
{
    public class BusinessInformationQueryService : IBusinessInformationQueryService
    {
        //private readonly ISession _eventStoreSession;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;
        private readonly SiteProvisioningService _siteProvisioningService;
        private readonly ILocationRepository _locationRepository;
        private readonly ISiteRepository _siteRepository;

        public BusinessInformationQueryService(/*ISession eventStoreSession, */
                                          IMapper mapper,
                                            IEventPublisher eventPublisher,
                                          ISiteRepository siteRepository,
                                          ILocationRepository locationRepository,
                                          SiteProvisioningService siteProvisioningService)
        {
            //_eventStoreSession = eventStoreSession;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _siteRepository = siteRepository;
            _locationRepository = locationRepository;
            _siteProvisioningService = siteProvisioningService;
        }

        public LocationViewModel FindLocation(Guid locationId)
        {
            var location = _locationRepository.Find(locationId);
            return _mapper.Map<LocationViewModel>(location);
        }

        public IEnumerable<LocationViewModel> FindLocations()
        {
            var locations = _locationRepository.Find(_ => true);
            return from location in locations
                select _mapper.Map<LocationViewModel>(location);

        }

        public IEnumerable<SiteViewModel> FindSites()
        {
            var sites = _siteRepository.Find(_ => true);
            return from s in sites
                   select new SiteViewModel
                   {
                       Id = s.Id,
                       Name = s.Name,
                       Description = s.Description,
                        TenantId = s.TenantId.Id,

                   };
        }
    }
}
