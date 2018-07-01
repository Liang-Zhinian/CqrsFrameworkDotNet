using System;
using Business.Contracts.Events;
using Business.Contracts.Events.ServiceCategory;
using CqrsFramework.Events;

namespace Registration.Domain.EventHandlers
{
    public class TestEventHandler : IEventHandler<TestedEvent>
    {
        public void Handle(TestedEvent @event)
        {

            Console.WriteLine("Event handled.");
        }
    }
}
