using System;
using Business.Contracts.Events.Sites;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace Business.Domain.Services
{
    public class SiteProvisioningService
    {
        private readonly IIntegrationEventService _integrationEventService;
        private readonly ISiteRepository _siteRepository;

        public SiteProvisioningService(/*ISession eventStore, */
                                       IIntegrationEventService integrationEventService,
                                       ISiteRepository siteRepository)
        {
            //_eventStore = eventStore;
            _integrationEventService = integrationEventService;
            _siteRepository = siteRepository;
        }

        public Site ProvisionSite(TenantId tenantId, string siteName, string siteDescription, bool active){
            Site site = new Site(tenantId, siteName, siteDescription, active);

            site.CreateBranding(new byte[] { 0 }, "#", "#", "#", "#");
            _siteRepository.Add(site);

            _integrationEventService.PublishThroughEventBus(new SiteCreatedEvent(site.Id, siteName, siteDescription, active, tenantId.Id));
            //_siteRepository.UnitOfWork.Commit();
            //_siteRepository.SaveChanges();

            // To Do: send event
            //_eventStore.Add<Site>(site);
            //_eventStore.Commit();

            return site;
        }
    }
}
