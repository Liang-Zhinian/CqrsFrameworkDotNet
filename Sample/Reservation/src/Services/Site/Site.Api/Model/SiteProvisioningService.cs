using System;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using SaaSEqt.eShop.Site.Api.Events.Sites;

namespace SaaSEqt.eShop.Site.Api.Model
{
    public class SiteProvisioningService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly SiteDbContext _context;

        public SiteProvisioningService(IEventPublisher eventPublisher,
                                       SiteDbContext context)
        {
            _eventPublisher = eventPublisher;
            _context = context;
        }

        public Site ProvisionSite(Guid tenantId, string siteName, string siteDescription, bool active){
            Site site = new Site(tenantId, siteName, siteDescription, active);

            _context.Sites.Add(site);
            site.CreateBranding(new byte[]{0}, "#", "#", "#", "#");

            _eventPublisher.Publish(new SiteCreatedEvent(site.Id, siteName, siteDescription, active, tenantId.ToString()));

            _context.SaveChanges();

            // To Do: send event
            //_eventStore.Add<Site>(site);
            //_eventStore.Commit();

            return site;
        }
    }
}
