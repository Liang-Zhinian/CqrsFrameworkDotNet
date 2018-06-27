using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Domain.Services;

using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace Business.Application.Services
{
    public class BusinessInformationService : IBusinessInformationService
    {
        private readonly ISession _eventStoreSession;
        private readonly IMapper _mapper;
        private readonly SiteProvisioningService _siteProvisioningService;
        private readonly ILocationRepository _locationRepository;
        private readonly ISiteRepository _siteRepository;

        public BusinessInformationService(ISession eventStoreSession, 
                                          IMapper mapper,
                                          ISiteRepository siteRepository,
                                          ILocationRepository locationRepository,
                                          SiteProvisioningService siteProvisioningService)
        {
            _eventStoreSession = eventStoreSession;
            _mapper = mapper;
            _siteRepository = siteRepository;
            _locationRepository = locationRepository;
            _siteProvisioningService = siteProvisioningService;
        }

        public LocationViewModel ProvisionLocation(LocationViewModel locationViewModel)
        {
            var existingSite = _siteRepository.Find(locationViewModel.SiteId);

            ContactInformation contactInformation = new ContactInformation();
            contactInformation.ContactName = locationViewModel.ContactName;
            contactInformation.PrimaryTelephone = locationViewModel.PrimaryTelephone;
            contactInformation.SecondaryTelephone = locationViewModel.SecondaryTelephone;

            var location = existingSite.ProvisionLocation(locationViewModel.Name, locationViewModel.Description, locationViewModel.Image, contactInformation);

            _siteRepository.Update(existingSite);
            _siteRepository.SaveChanges();

            _eventStoreSession.Add(location);
            _eventStoreSession.Commit();

            return _mapper.Map<LocationViewModel>(location);
        }

        public SiteViewModel ProvisionSite(string tenantId, string siteName, string siteDescription, bool active)
        {
            Site site = _siteProvisioningService.ProvisionSite(new TenantId(tenantId), siteName, siteDescription, active);

            //this.ProvisionLocation(site.Name, site.Description, new byte[] { 0 }, site.ContactInformation);

            var siteView = _mapper.Map<SiteViewModel>(site);
            return siteView;
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

        public void SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            var location = _locationRepository.Find(_=>_.SiteId.Equals(siteId) && _.Id.Equals(locationId)).FirstOrDefault();

            PostalAddress postalAddress = new PostalAddress( streetAddress,
                              streetAddress2,
                              city,
                              stateProvince,
                              postalCode,
                                                             countryCode);

            location.ChangeAddress(postalAddress);

            _locationRepository.SaveChanges();

        }

        public void SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude){
            var location = _locationRepository.Find(_ => _.SiteId.Equals(siteId) && _.Id.Equals(locationId)).FirstOrDefault();

            Geolocation geolocation = new Geolocation(latitude, longitude);

            location.SetGeolocation(geolocation);

            _locationRepository.SaveChanges();
        }

        public void SetLocationImage(Guid siteId, Guid locationId, byte[] image)
        {
            var location = _eventStoreSession.Get<Location>(locationId); //_locationRepository.Find(_ => _.SiteId.Equals(siteId) && _.Id.Equals(locationId)).FirstOrDefault();

            location.SetLocationImage(image);

            _locationRepository.SaveChanges();

            //_eventStoreSession.Get<Location>(locationId);
            _eventStoreSession.Commit();
        }
    }
}
