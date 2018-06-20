using System;
using Business.Contracts.Events.ServiceCategory;
using CqrsFramework.Events;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class ServiceCategoryEventHandler : IEventHandler<ServiceCreatedEvent>
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceCategoryEventHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public void Handle(ServiceCreatedEvent @event)
        {
            Console.WriteLine("Event handled.");
            // save to ReadDB
            Service service = new Service(@event.TenantId,
                                           @event.CategoryId,
                                           @event.Name,
                                           @event.Description); //_mapper.Map<LocationRM>(message);

            _serviceRepository.Add(service);
            _serviceRepository.SaveChanges();

        }
    }
}
