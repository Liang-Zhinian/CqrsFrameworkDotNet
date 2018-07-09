using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Sites;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace Business.Domain.Services
{
    public class SiteProvisioningService
    {
        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly ISiteRepository _siteRepository;

        public SiteProvisioningService(IBusinessIntegrationEventService businessIntegrationEventService,
                                       ISiteRepository siteRepository)
        {
            _businessIntegrationEventService = businessIntegrationEventService;
            _siteRepository = siteRepository;
        }

        public async Task<Site> ProvisionSite(TenantId tenantId, string siteName, string siteDescription, string contactName, string primaryTelephone, string secondaryTelephone, string emailAddress, bool active){
            ContactInformation contactInformation = new ContactInformation( contactName,  primaryTelephone,  secondaryTelephone, emailAddress);

            Site site = new Site(tenantId, siteName, siteDescription, active, contactInformation);

            _siteRepository.Add(site);

            site.UpdateBranding(new byte[] { 0 }, "#", "#", "#", "#");

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new SiteCreatedEvent(
                                                                   tenantId.Id, 
                                                                    site.Id, 
                                                                   siteName, 
                                                                   siteDescription, 
                                                                   active, 
                                                                   contactInformation.ContactName, 
                                                                   contactInformation.PrimaryTelephone, 
                                                                   contactInformation.SecondaryTelephone));
          
            return site;
        }
    }
}
