using System;
using CqrsFramework.Events;
using SaaSEqt.eShop.Site.Api.Events.Tenants;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;
using SaaSEqt.eShop.Site.Api.Services;

namespace Site.Api.Events.EventHandling
{
    public class TenantEventHandler : IEventHandler<TenantCreatedEvent>
    {
        private IBusinessInformationService _businessInformationService;

        public TenantEventHandler(IBusinessInformationService businessInformationService)
        {
            _businessInformationService = businessInformationService;
        }

        public void Handle(TenantCreatedEvent message)
        {
            Console.WriteLine("Handling TenantCreatedEvent.");
            _businessInformationService.ProvisionSite(message.Id, message.Name,
                                                      message.Description, true);
        }
    }
}
