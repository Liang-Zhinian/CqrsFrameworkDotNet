using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Security.Tenants;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class TenantEventHandler : IEventHandler<TenantCreatedEvent>
    {
        private ITenantRepository _tenantRepository;

        public TenantEventHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public Task Handle(TenantCreatedEvent message)
        {
            Console.WriteLine("Handling TenantCreatedEvent.");
            Tenant tenant = new Tenant (
                    message.Id,
                    message.Name,
                    message.Description
                );
            try
            {
                _tenantRepository.Add(tenant);
                _tenantRepository.SaveChanges();
                Console.WriteLine("TenantCreatedEvent handled.");
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
