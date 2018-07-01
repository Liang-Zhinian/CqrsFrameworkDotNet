using System;
using Business.Contracts.Events.ServiceCategory;
using CqrsFramework.Events;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class ServiceCategoryEventHandler : IEventHandler<ServiceCreatedEvent>,
                                                IEventHandler<ServiceCategoryCreatedEvent>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;

        public ServiceCategoryEventHandler(IServiceCategoryRepository serviceCategoryRepository,
                                           IServiceRepository serviceRepository)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceRepository = serviceRepository;
        }

        public void Handle(ServiceCreatedEvent @event)
        {
            Console.WriteLine("Handling ServiceCreatedEvent.");
            // save to ReadDB
            Service service = new Service(@event.CategoryId,
                                           @event.Name,
                                           @event.Description); //_mapper.Map<LocationRM>(message);
            try
            {
                _serviceRepository.Add(service);
                _serviceRepository.SaveChanges();
                Console.WriteLine("ServiceCreatedEvent handled.");
            }catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }

        }

        public void Handle(ServiceCategoryCreatedEvent message)
        {

            Console.WriteLine("Event handled.");
            // save to ReadDB
            ServiceCategory serviceCategory = new ServiceCategory(message.Id,
                                                                    message.Name,
                                                                    message.Description,
                                                                    10,
                                                                    1,
                                                                    message.Id,
                                                                    false); //_mapper.Map<LocationRM>(message);
            try
            {
                _serviceCategoryRepository.Add(serviceCategory);
                _serviceCategoryRepository.SaveChanges();
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
