using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.ViewModels;
using Business.Domain.Entities;

namespace Business.Application.Interfaces
{
    public interface IBusinessInformationService
    {
        IEnumerable<SiteViewModel> FindSites();
        SiteViewModel ProvisionSite(string tenantId, string siteName, string siteDescription, bool active);
        Task<LocationViewModel> ProvisionLocationAsync(LocationViewModel locationViewModel);
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
        void AddAdditionalLocationImage(Guid siteId, Guid locationId, byte[] image);
    }
}
