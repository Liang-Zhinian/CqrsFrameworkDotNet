using System;
using System.Threading.Tasks;
using Business.Contracts.Events.ServiceCategory;
using CqrsFramework.Events;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class ServiceCategoryEventHandler : IEventHandler<ServiceItemCreatedEvent>,
                                                IEventHandler<ServiceCategoryCreatedEvent>
    {
        private readonly IServiceItemRepository _serviceRepository;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;

        public ServiceCategoryEventHandler(IServiceCategoryRepository serviceCategoryRepository,
                                           IServiceItemRepository serviceRepository)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceRepository = serviceRepository;
        }

        public Task Handle(ServiceItemCreatedEvent @event)
        {
            Console.WriteLine("Handling ServiceItemCreatedEvent.");
            // save to ReadDB
            ServiceItem serviceItem = new ServiceItem(@event.SiteId,
                                                  @event.ServiceCategoryId,
                                           @event.Name,
                                           @event.Description,
                                                  @event.DefaultTimeLength); //_mapper.Map<LocationRM>(message);
            try
            {
                _serviceRepository.Add(serviceItem);
                _serviceRepository.SaveChanges();
                Console.WriteLine("ServiceItemCreatedEvent handled.");
                return Task.CompletedTask;
            }catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }

        }

        public Task Handle(ServiceCategoryCreatedEvent message)
        {
            
            Console.WriteLine("ServiceCategoryCreatedEvent handled.");
            // save to ReadDB
            ServiceCategory serviceCategory = new ServiceCategory(message.Id,
                                                                    message.Name,
                                                                    message.Description,
                                                                    10,
                                                                    1,
                                                                    message.SiteId); //_mapper.Map<LocationRM>(message);
            try
            {
                _serviceCategoryRepository.Add(serviceCategory);
                _serviceCategoryRepository.SaveChanges();
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
