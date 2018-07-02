using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Sites;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class SiteEventHandler : IEventHandler<SiteCreatedEvent>
    {
        private readonly ISiteRepository _siteRepository;

        public SiteEventHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public Task Handle(SiteCreatedEvent message)
        {
            Console.WriteLine("Handling TenantCreatedEvent.");

            Site site = new Site(
                    message.Id,
                    message.Name,
                    message.Description,
                    Guid.Parse(message.TenantId)
                );
            try
            {
                _siteRepository.Add(site);
                _siteRepository.SaveChanges();
                Console.WriteLine("SiteCreatedEvent handled.");

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
