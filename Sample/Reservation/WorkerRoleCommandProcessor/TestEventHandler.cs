using System;
using Business.Domain.Events.ServiceCategory;
using CqrsFramework.Events;

namespace WorkerRoleCommandProcessor
{
    public class TestEventHandler : IEventHandler<ServiceCreatedEvent>
    {
        public void Handle(ServiceCreatedEvent @event)
        {

            Console.WriteLine("Event handled.");
        }
    }
}
