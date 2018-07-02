using System;
using System.Threading.Tasks;
using Business.Contracts.Events;
using Business.Contracts.Events.ServiceCategory;
using CqrsFramework.Events;
using CqrsFramework.Messages;

namespace Registration.Domain.EventHandlers
{
    public class TestEventHandler : IEventHandler<TestedEvent>
    {
        public Task Handle(TestedEvent @event)
        {

            Console.WriteLine("Event handled.");
            return Task.CompletedTask;
        }
    }
}
