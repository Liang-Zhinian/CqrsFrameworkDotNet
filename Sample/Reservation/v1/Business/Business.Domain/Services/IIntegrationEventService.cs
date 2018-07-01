using System;
using System.Threading.Tasks;
using CqrsFramework.Events;

namespace Business.Domain.Services
{
    public interface IIntegrationEventService
    {
        Task PublishThroughEventBusAsync(IEvent evt);
        void PublishThroughEventBus(IEvent evt);
    }
}
