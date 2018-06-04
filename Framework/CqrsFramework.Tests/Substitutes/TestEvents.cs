using System;
using System.Threading.Tasks;
using CqrsFramework.Domain.Exception;
using CqrsFramework.Events;

namespace CqrsFramework.Tests.Substitutes
{
    public class TestAggregateDidSomething : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public bool LongRunning { get; set; }
    }
    public class TestAggregateDidSomeethingElse : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }

    public class TestAggregateDidSomethingHandler : IEventHandler<TestAggregateDidSomething>
    {
        public void Handle(TestAggregateDidSomething message)
        {
            if (message.LongRunning)
                Task.Delay(50);
            lock (message)
            {
                if(message.Version == -10)
                    throw new ConcurrencyException(message.Id);
                TimesRun++;
            }
        }

        public int TimesRun { get; private set; }
    }
}
