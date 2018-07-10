using System;
using System.Threading.Tasks;
using CqrsFramework.Events;
using CqrsFramework.Messages;
using SaaSEqt.eShop.Site.Api.Events.Tenants;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;
using SaaSEqt.eShop.Site.Api.Application.Services;

namespace SaaSEqt.eShop.Site.Api.Events.EventHandling
{
    public class TenantEventHandler : IEventHandler<TenantCreatedEvent>
    {
        private IBusinessInformationService _businessInformationService;

        public TenantEventHandler(IBusinessInformationService businessInformationService)
        {
            _businessInformationService = businessInformationService;
        }

        public async Task Handle(TenantCreatedEvent message)
        {
            //Console.WriteLine("Handling TenantCreatedEvent.");
            //await _businessInformationService.ProvisionSite(message.Id, message.Name,
            //message.Description, true);
            throw new NotImplementedException();
        }
    }
}
