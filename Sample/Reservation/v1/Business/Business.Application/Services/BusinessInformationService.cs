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
        //private readonly ISession _eventStoreSession;
        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly IMapper _mapper;
        private readonly SiteProvisioningService _siteProvisioningService;
        private readonly ISiteRepository _siteRepository;
        private readonly ILocationRepository _locationRepository;

        public BusinessInformationService(//ISession eventStoreSession,
                                          IBusinessIntegrationEventService businessIntegrationEventService,
                                          IMapper mapper,
                                          SiteProvisioningService siteProvisioningService,
                                          ISiteRepository siteRepository,
                                          ILocationRepository locationRepository)
        {
            //_eventStoreSession = eventStoreSession;
            _businessIntegrationEventService = businessIntegrationEventService;
            _mapper = mapper;
            _siteProvisioningService = siteProvisioningService;
            _siteRepository = siteRepository;
            _locationRepository = locationRepository;
        }

        #region site services

        public async Task<SiteViewModel> ProvisionSite(ProvisionSiteCommand provisionSiteCommand)
        {
            Site site = await _siteProvisioningService.ProvisionSite(new TenantId(provisionSiteCommand.TenantId),
                                                               provisionSiteCommand.Name,
                                                               provisionSiteCommand.Description,
                                                               provisionSiteCommand.ContactName,
                                                               provisionSiteCommand.PrimaryTelephone,
                                                               provisionSiteCommand.SecondaryTelephone,
                                                               provisionSiteCommand.EmailAddress,
                                                               provisionSiteCommand.Active);

            //await _eventStoreSession.Add<Site>(site);
            //await _eventStoreSession.Commit();

            //_siteRepository.UnitOfWork.Commit();

            //_businessIntegrationEventService.SaveEventAndBusinessDbContextChangesAsync();

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
            var existingSite = _siteRepository.Find(provisionLocationCommand.SiteId); //await _eventStoreSession.Get<Site>(provisionLocationCommand.SiteId);

            ContactInformation contactInformation = new ContactInformation(provisionLocationCommand.ContactName, provisionLocationCommand.PrimaryTelephone, provisionLocationCommand.SecondaryTelephone, provisionLocationCommand.EmailAddress);

            var location = existingSite.ProvisionLocation(provisionLocationCommand.Name, provisionLocationCommand.Description, contactInformation);


            //await _eventStoreSession.Add<Location>(location);
            //await _eventStoreSession.Commit();

            //var site = _siteRepository.Find(provisionLocationCommand.SiteId);
            //site.ProvisionLocation(provisionLocationCommand.Name, provisionLocationCommand.Description, contactInformation);

            //_siteRepository
            //_siteRepository.UnitOfWork.Commit();

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new LocationCreatedEvent(
                location.Id,
                provisionLocationCommand.SiteId,
                    provisionLocationCommand.Name, 
                    provisionLocationCommand.Description,
                     contactInformation.ContactName,
                     contactInformation.EmailAddress,
                     contactInformation.PrimaryTelephone,
                     contactInformation.SecondaryTelephone
                 )
            );


            return _mapper.Map<LocationViewModel>(location);
        }


        public async Task SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode)
        {
            var location = FindExistingLocation(siteId, locationId); //await _eventStoreSession.Get<Location>(locationId);

            PostalAddress postalAddress = new PostalAddress(streetAddress,
                              streetAddress2,
                              city,
                              stateProvince,
                              postalCode,
                                                             countryCode);

            location.ChangeAddress(postalAddress);

            //await _eventStoreSession.Add<Location>(location);
            //await _eventStoreSession.Commit();

            //_locationRepository.Update(location);
            //_locationRepository.UnitOfWork.Commit();

            await _businessIntegrationEventService
                .PublishThroughEventBusAsync(new LocationAddressChangedEvent(location.Id, 
                                                                             location.SiteId, 
                                                                             postalAddress.StreetAddress,
                                                        postalAddress.StreetAddress2, 
                                                                             postalAddress.City,
                                                        postalAddress.StateProvince, 
                                                                             postalAddress.PostalCode,
                                                        postalAddress.CountryCode)
            );
        }

        public async Task SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude)
        {
            var location = FindExistingLocation(siteId, locationId);

            Geolocation geolocation = new Geolocation(latitude, longitude);

            location.SetGeolocation(geolocation);


            //await _eventStoreSession.Add<Location>(location);
            //await _eventStoreSession.Commit();

            //_locationRepository.Update(location);
            //_locationRepository.UnitOfWork.Commit();

            await _businessIntegrationEventService
                .PublishThroughEventBusAsync(new LocationGeolocationChangedEvent(
                    locationId, 
                    siteId, 
                    latitude, 
                    longitude));
        }

        public async Task UpdateLocationImage(UpdateLocationImageCommand updateLocationImageCommand)
        {
            //Guid siteId, Guid locationId, byte[] image
            var location = FindExistingLocation(updateLocationImageCommand.SiteId, updateLocationImageCommand.LocationId);

            location.SetLocationImage(updateLocationImageCommand.Image);

            //await _eventStoreSession.Add<Location>(location);
            //await _eventStoreSession.Commit();

            //_locationRepository.Update(location);
            //_locationRepository.UnitOfWork.Commit();

            await _businessIntegrationEventService
                .PublishThroughEventBusAsync(new LocationImageChangedEvent(location.Id, 
                                                                           location.SiteId, 
                                                                           updateLocationImageCommand.Image));
        }

        public async Task AddAdditionalLocationImage(Guid siteId, Guid locationId, byte[] image)
        {
            var location = FindExistingLocation(siteId, locationId);

            var locationImage = new LocationImage(siteId, locationId, image);
            location.AddImage(locationImage);

            //await _eventStoreSession.Add<Location>(location);
            //await _eventStoreSession.Commit();

            //_locationRepository.Update(location);
            //_locationRepository.UnitOfWork.Commit();


            await _businessIntegrationEventService
                .PublishThroughEventBusAsync(new AdditionalLocationImageCreatedEvent(location.Id,
                                                                           location.SiteId,
                                                                                     image));
        }

        #endregion

        private Location FindExistingLocation(Guid siteId, Guid locationId){
            var location = _locationRepository.Find(locationId);
            return location;
        }
    }
}
