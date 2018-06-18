using System;
using Business.Domain.Events.ServiceCategory;
using CqrsFramework.Events;
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
            // save to ReadDB
            //Service location = _mapper.Map<LocationRM>(message);

            //_serviceRepository.Add();
            //_serviceRepository.SaveChanges();

        }
    }
}
