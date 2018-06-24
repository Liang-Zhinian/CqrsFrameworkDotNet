using System;
using System.Collections.Generic;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface IBusinessInformationService
    {
        SiteViewModel ProvisionSite(string tenantId, string siteName, string siteDescription, bool active);
        LocationViewModel ProvisionLocation(LocationViewModel locationViewModel);
        LocationViewModel FindLocation(Guid locationId);
        IEnumerable<LocationViewModel> FindLocations();
    }
}
