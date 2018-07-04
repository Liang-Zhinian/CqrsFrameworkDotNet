using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.ViewModels;
using Business.Domain.Entities;

namespace Business.Application.Interfaces
{
    public interface IBusinessInformationQueryService
    {
        IEnumerable<SiteViewModel> FindSites();
        LocationViewModel FindLocation(Guid locationId);
        IEnumerable<LocationViewModel> FindLocations();

    }

    public interface IBusinessInformationService
    {
        Task<SiteViewModel> ProvisionSite(string tenantId, string siteName, string siteDescription, bool active);
        Task<LocationViewModel> ProvisionLocationAsync(LocationViewModel locationViewModel);
        Task SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode);
        Task SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude);
        Task SetLocationImage(Guid siteId, Guid locationId, byte[] image);
        Task AddAdditionalLocationImage(Guid siteId, Guid locationId, byte[] image);
    }
}
