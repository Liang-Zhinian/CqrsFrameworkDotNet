using System;
using System.Threading.Tasks;
using CqrsFramework.Events;

namespace Business.Domain.SeedWork
{
    public interface IBusinessIntegrationEventService
    {
        //Task SaveEventAndBusinessDbContextChangesAsync(IEvent evt);
        Task PublishThroughEventBusAsync(IEvent evt);
    }
}
