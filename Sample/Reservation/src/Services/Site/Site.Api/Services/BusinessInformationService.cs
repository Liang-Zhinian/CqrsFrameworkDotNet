using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SaaSEqt.eShop.Site.Api.ViewModel;
using SaaSEqt.eShop.Site.Api.Events.Locations;
using SaaSEqt.eShop.Site.Api.Model;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;

using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace SaaSEqt.eShop.Site.Api.Services
{
    public class BusinessInformationService : IBusinessInformationService
    {
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;
        private readonly SiteDbContext _context;
        private readonly SiteProvisioningService _siteProvisioningService;

        public BusinessInformationService(IMapper mapper,
                             IEventPublisher eventPublisher,
                                          SiteDbContext context,
                                          SiteProvisioningService siteProvisioningService)
        {
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _context = context;
            _siteProvisioningService = siteProvisioningService;
        }

        public LocationViewModel ProvisionLocation(LocationViewModel locationViewModel)
        {
            var existingSite = _context.Sites.Find(locationViewModel.SiteId);

            ContactInformation contactInformation = new ContactInformation();
            contactInformation.ContactName = locationViewModel.ContactName;
            contactInformation.PrimaryTelephone = locationViewModel.PrimaryTelephone;
            contactInformation.SecondaryTelephone = locationViewModel.SecondaryTelephone;

            var location = existingSite.ProvisionLocation(locationViewModel.Name, locationViewModel.Description, locationViewModel.Image, contactInformation);

            _eventPublisher.Publish<LocationCreatedEvent>(new LocationCreatedEvent(
                                                                location.Id,
                                                                location.SiteId,
                                                                location.Name,
                                                                location.Description,
                                                                location.Image,
                                                                     contactInformation.PrimaryTelephone,
                                                                     contactInformation.SecondaryTelephone
                                                            )
                                                         );

            _context.Sites.Update(existingSite);
            _context.SaveChanges();

            //_eventStoreSession.Add(location);
            //_eventStoreSession.Commit();

            return _mapper.Map<LocationViewModel>(location);
        }

        public SiteViewModel ProvisionSite(Guid tenantId, string siteName, string siteDescription, bool active)
        {
            Model.Site site = _siteProvisioningService.ProvisionSite(tenantId, siteName, siteDescription, active);

            var siteView = _mapper.Map<SiteViewModel>(site);
            return siteView;
        }

        public LocationViewModel FindLocation(Guid locationId)
        {
            var location = _context.Locations.Find(locationId);
            return _mapper.Map<LocationViewModel>(location);
        }

        public IEnumerable<LocationViewModel> FindLocations()
        {
            var locations = _context.Locations;
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
            var location = _context.Locations.Where(_=>_.SiteId.Equals(siteId) && _.Id.Equals(locationId)).FirstOrDefault();

            PostalAddress postalAddress = new PostalAddress( streetAddress,
                              streetAddress2,
                              city,
                              stateProvince,
                              postalCode,
                                                             countryCode);

            location.ChangeAddress(postalAddress);

            _eventPublisher.Publish<LocationAddressChangedEvent>(new LocationAddressChangedEvent(location.Id, location.SiteId, postalAddress.StreetAddress,
                                                        postalAddress.StreetAddress2, postalAddress.City,
                                                        postalAddress.StateProvince, postalAddress.PostalCode,
                                                        postalAddress.CountryCode));

            _context.SaveChanges();

        }

        public void SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude){
            var location = _context.Locations.Where(_ => _.SiteId.Equals(siteId) && _.Id.Equals(locationId)).FirstOrDefault();

            Geolocation geolocation = new Geolocation(latitude, longitude);

            location.SetGeolocation(geolocation);

            _eventPublisher.Publish<LocationGeolocationChangedEvent>(new LocationGeolocationChangedEvent(location.Id, location.SiteId, geolocation.Latitude, geolocation.Longitude));

            _context.SaveChanges();
        }

        public void SetLocationImage(Guid siteId, Guid locationId, byte[] image)
        {
            var location = _context.Locations.Where(_ => _.SiteId.Equals(siteId) && _.Id.Equals(locationId)).FirstOrDefault();

            location.SetLocationImage(image);

            _eventPublisher.Publish<LocationImageChangedEvent>(new LocationImageChangedEvent(location.Id, location.SiteId, image));

            _context.SaveChanges();

            //_eventStoreSession.Get<Location>(locationId);
            //_eventStoreSession.Commit();
        }
    }
}
