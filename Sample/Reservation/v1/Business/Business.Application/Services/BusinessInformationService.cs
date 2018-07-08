using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Commands.Locations;
using Business.Contracts.Commands.Sites;
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
        private readonly ISiteRepository _siteRepository;
        private readonly ILocationRepository _locationRepository;

        public BusinessInformationService(ISession eventStoreSession,
                                          IMapper mapper,
                                          SiteProvisioningService siteProvisioningService,
                                          ISiteRepository siteRepository,
                                          ILocationRepository locationRepository)
        {
            _eventStoreSession = eventStoreSession;
            _mapper = mapper;
            _siteProvisioningService = siteProvisioningService;
            _siteRepository = siteRepository;
            _locationRepository = locationRepository;
        }

        #region site services

        public async Task<SiteViewModel> ProvisionSite(ProvisionSiteCommand provisionSiteCommand)
        {
            Site site = _siteProvisioningService.ProvisionSite(new TenantId(provisionSiteCommand.TenantId),
                                                               provisionSiteCommand.Name,
                                                               provisionSiteCommand.Description,
                                                               provisionSiteCommand.ContactName,
                                                               provisionSiteCommand.PrimaryTelephone,
                                                               provisionSiteCommand.SecondaryTelephone,
                                                               provisionSiteCommand.EmailAddress,
                                                               provisionSiteCommand.Active);

            await _eventStoreSession.Add<Site>(site);
            await _eventStoreSession.Commit();

            _siteRepository.UnitOfWork.Commit();

            var siteView = _mapper.Map<SiteViewModel>(site);
            return siteView;
        }

        public Task<SiteViewModel> UpdateSiteDescription(UpdateSiteDescriptionCommand updateSiteDescriptionCommand)
        {
            throw new NotImplementedException();
        }

        public Task<SiteViewModel> UpdateSiteContactInformation(UpdateSiteContactInformationCommand updateSiteContactInformationCommand)
        {
            throw new NotImplementedException();
        }

        public Task<SiteViewModel> UpdateSiteBranding(UpdateSiteBrandingCommand updateSiteBrandingCommand)
        {
            throw new NotImplementedException();
        }

        public Task ActivateSite(ActivateSiteCommand activateSiteCommand)
        {
            throw new NotImplementedException();
        }

        public Task DeactivateSite(DeactivateSiteCommand deactivateSiteCommand)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Location services

        public async Task<LocationViewModel> ProvisionLocationAsync(ProvisionLocationCommand provisionLocationCommand)
        {
            var existingSite = await _eventStoreSession.Get<Site>(provisionLocationCommand.SiteId);

            ContactInformation contactInformation = new ContactInformation(provisionLocationCommand.ContactName, provisionLocationCommand.PrimaryTelephone, provisionLocationCommand.SecondaryTelephone, provisionLocationCommand.EmailAddress);

            var location = existingSite.ProvisionLocation(provisionLocationCommand.Name, provisionLocationCommand.Description, contactInformation);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();

            _siteRepository.Update(existingSite);
            _siteRepository.UnitOfWork.Commit();

            return _mapper.Map<LocationViewModel>(location);
        }


        public async Task SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            var location = await _eventStoreSession.Get<Location>(locationId);

            PostalAddress postalAddress = new PostalAddress(streetAddress,
                              streetAddress2,
                              city,
                              stateProvince,
                              postalCode,
                                                             countryCode);

            location.ChangeAddress(postalAddress);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();

            _locationRepository.Update(location);
            _locationRepository.UnitOfWork.Commit();
        }

        public async Task SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude)
        {
            var location = await _eventStoreSession.Get<Location>(locationId);

            Geolocation geolocation = new Geolocation(latitude, longitude);

            location.SetGeolocation(geolocation);


            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();

            _locationRepository.Update(location);
            _locationRepository.UnitOfWork.Commit();
        }

        public async Task UpdateLocationImage(UpdateLocationImageCommand updateLocationImageCommand)
        {
            //Guid siteId, Guid locationId, byte[] image
            var location = await _eventStoreSession.Get<Location>(updateLocationImageCommand.LocationId);

            location.SetLocationImage(updateLocationImageCommand.Image);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();

            _locationRepository.Update(location);
            _locationRepository.UnitOfWork.Commit();
        }

        public async Task AddAdditionalLocationImage(Guid siteId, Guid locationId, byte[] image)
        {
            var location = await _eventStoreSession.Get<Location>(locationId);

            var locationImage = new LocationImage(siteId, locationId, image);
            location.AddImage(locationImage);

            await _eventStoreSession.Add<Location>(location);
            await _eventStoreSession.Commit();

            _locationRepository.Update(location);
            _locationRepository.UnitOfWork.Commit();
        }

        #endregion
    }
}
