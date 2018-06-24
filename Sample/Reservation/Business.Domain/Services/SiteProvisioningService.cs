using System;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using CqrsFramework.Domain;

namespace Business.Domain.Services
{
    public class SiteProvisioningService
    {
        private readonly ISession _eventStore;
        private readonly ISiteRepository _siteRepository;

        public SiteProvisioningService(ISession eventStore, ISiteRepository siteRepository)
        {
            _eventStore = eventStore;
            _siteRepository = siteRepository;
        }

        public Site ProvisionSite(TenantId tenantId, string siteName, string siteDescription, bool active){
            Site site = new Site(tenantId, siteName, siteDescription, active);

            _siteRepository.Add(site);
            site.CreateBranding(new byte[]{0}, "#", "#", "#", "#");
            _siteRepository.SaveChanges();

            // To Do: send event
            _eventStore.Add<Site>(site);
            _eventStore.Commit();

            return site;
        }
    }
}
