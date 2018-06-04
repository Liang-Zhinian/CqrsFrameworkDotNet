using CqrsFramework.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsFramework.Tests.Substitutes
{
    public class TestEventPublisher : IEventPublisher
    {
        public void Publish<T>(T @event) where T : IEvent
        {
            Published++;
        }

        public int Published { get; private set; }
    }
}
