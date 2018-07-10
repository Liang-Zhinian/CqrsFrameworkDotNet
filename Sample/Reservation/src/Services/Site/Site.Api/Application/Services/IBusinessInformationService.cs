using System;
using System.Collections.Generic;
using SaaSEqt.eShop.Site.Api.ViewModel;

namespace SaaSEqt.eShop.Site.Api.Application.Services
{
    public interface IBusinessInformationService
    {
        SiteViewModel ProvisionSite(Guid tenantId, string siteName, string siteDescription, bool active);
        LocationViewModel ProvisionLocation(LocationViewModel locationViewModel);
        LocationViewModel FindLocation(Guid locationId);
        IEnumerable<LocationViewModel> FindLocations();
        void SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode);
        void SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude);
        void SetLocationImage(Guid siteId, Guid locationId, byte[] image);
    }
}
