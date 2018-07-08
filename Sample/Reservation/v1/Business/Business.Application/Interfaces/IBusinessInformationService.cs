using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.ViewModels;
using Business.Contracts.Commands.Locations;
using Business.Contracts.Commands.Sites;
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
        #region site services

        Task<SiteViewModel> ProvisionSite(ProvisionSiteCommand provisionSiteCommand);
        Task<SiteViewModel> UpdateSiteDescription(UpdateSiteDescriptionCommand updateSiteDescriptionCommand);
        Task<SiteViewModel> UpdateSiteContactInformation(UpdateSiteContactInformationCommand updateSiteContactInformationCommand);
        Task<SiteViewModel> UpdateSiteBranding(UpdateSiteBrandingCommand updateSiteBrandingCommand);
        Task ActivateSite(ActivateSiteCommand activateSiteCommand);
        Task DeactivateSite(DeactivateSiteCommand deactivateSiteCommand);

        #endregion

        #region Location services

        Task<LocationViewModel> ProvisionLocationAsync(ProvisionLocationCommand provisionLocationCommand);
        Task SetLocationAddress(Guid siteId, Guid locationId, string streetAddress,
                             string streetAddress2,
                             string city,
                             string stateProvince,
                             string postalCode,
                             string countryCode);
        Task SetLocationGeolocation(Guid siteId, Guid locationId, double? latitude, double? longitude);
        Task UpdateLocationImage(UpdateLocationImageCommand updateLocationImageCommand);
        Task AddAdditionalLocationImage(Guid siteId, Guid locationId, byte[] image);

        #endregion
    }
}
