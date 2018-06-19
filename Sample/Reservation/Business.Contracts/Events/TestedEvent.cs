using System;
using CqrsFramework.Events;

namespace Business.Contracts.Events
{
    public class TestedEvent: IEvent
    {
        public TestedEvent()
        {
            Id = Guid.NewGuid();
            Version = 1;
            TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
