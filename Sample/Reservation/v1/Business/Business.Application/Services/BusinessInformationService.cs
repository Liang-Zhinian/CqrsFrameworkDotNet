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
    public class BusinessInformationService : IBusinessInformationService
    {
        private readonly ISession _eventStoreSession;
        private readonly IMapper _mapper;
        private readonly SiteProvisioningService _siteProvisioningService;

        public BusinessInformationService(ISession eventStoreSession,
                                          IMapper mapper,
                                          SiteProvisioningService siteProvisioningService)
        {
            _eventStoreSession = eventStoreSession;
            _mapper = mapper;
            _siteProvisioningService = siteProvisioningService;
        }

        public async Task<LocationViewModel> ProvisionLocationAsync(LocationViewModel locationViewModel)
        {
            var existingSite = await _eventStoreSession.Get<Site>(locationViewModel.SiteId);

            ContactInformation contactInformation = new ContactInformation();
            contactInformation.ContactName = locationViewModel.ContactName;
            contactInformation.PrimaryTelephone = locationViewModel.PrimaryTelephone;
            contactInformation.SecondaryTelephone = locationViewModel.SecondaryTelephone;

            var location = existingSite.ProvisionLocation(locationViewModel.Name, locationViewModel.Description, locationViewModel.Image, contactInformation);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();

            return _mapper.Map<LocationViewModel>(location);
        }

        public async Task<SiteViewModel> ProvisionSite(string tenantId, string siteName, string siteDescription, bool active)
        {
            Site site = _siteProvisioningService.ProvisionSite(new TenantId(tenantId), siteName, siteDescription, active);

            //this.ProvisionLocation(site.Name, site.Description, new byte[] { 0 }, site.ContactInformation);

            await _eventStoreSession.Add<Site>(site);
            await _eventStoreSession.Commit();

            var siteView = _mapper.Map<SiteViewModel>(site);
            return siteView;
        }

        public async Task SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            var location = await _eventStoreSession.Get<Location>(locationId);

            PostalAddress postalAddress = new PostalAddress( streetAddress,
                              streetAddress2,
                              city,
                              stateProvince,
                              postalCode,
                                                             countryCode);

            location.ChangeAddress(postalAddress);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();
        }

        public async Task SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude){
            var location = await _eventStoreSession.Get<Location>(locationId);

            Geolocation geolocation = new Geolocation(latitude, longitude);

            location.SetGeolocation(geolocation);


            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();
        }

        public async Task SetLocationImage(Guid siteId, Guid locationId, byte[] image)
        {
            var location = await _eventStoreSession.Get<Location>(locationId);

            location.SetLocationImage(image);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();
        }

        public async Task AddAdditionalLocationImage(Guid siteId, Guid locationId, byte[] image){
            var location = await _eventStoreSession.Get<Location>(locationId);

            var locationImage = new LocationImage(siteId, locationId, image);
            location.AddImage(locationImage);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();
        }
    }
}
