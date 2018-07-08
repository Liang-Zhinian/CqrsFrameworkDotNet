using System;
using System.Threading.Tasks;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;
using SaaSEqt.IdentityAccess.Contracts.IntegrationEvents.Tenant;

namespace Registration.Domain.EventHandlers
{
    public class TenantEventHandler : IEventHandler<TenantProvisionedIntegrationEvent>
    {
        private ITenantRepository _tenantRepository;

        public TenantEventHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public Task Handle(TenantProvisionedIntegrationEvent message)
        {
            Console.WriteLine("Handling TenantProvisionedIntegrationEvent.");
            Tenant tenant = new Tenant (
                    message.Id,
                    message.Name,
                    message.Description
                );
            try
            {
                _tenantRepository.Add(tenant);
                _tenantRepository.SaveChanges();
                Console.WriteLine("TenantProvisionedIntegrationEvent handled.");
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }
        }
    }
}
