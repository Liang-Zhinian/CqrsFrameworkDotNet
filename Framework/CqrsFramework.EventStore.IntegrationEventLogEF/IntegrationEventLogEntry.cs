using System;
using System.Collections.Generic;
using System.Text;
using CqrsFramework.Events;
using Newtonsoft.Json;

namespace CqrsFramework.EventStore.IntegrationEventLogEF
{
    public class IntegrationEventLogEntry
    {
        private IntegrationEventLogEntry() { }
        public IntegrationEventLogEntry(IEvent @event)
        {
            EventId = Guid.NewGuid();
            SourceId = @event.Id;
            CreationTime = @event.TimeStamp.DateTime;
            EventTypeName = @event.GetType().FullName;
            Content = JsonConvert.SerializeObject(@event);
            State = EventStateEnum.NotPublished;
            TimesSent = 0;
        }
        public IntegrationEventLogEntry(Guid eventId, string eventTypeName, DateTime creationTime, string content)
        {
            EventId = Guid.NewGuid();
            SourceId = eventId;
            CreationTime = creationTime;
            EventTypeName = eventTypeName;
            Content = content;
            State = EventStateEnum.NotPublished;
            TimesSent = 0;
        }

        public Guid EventId { get; private set; }
        public Guid SourceId { get; private set; }
        public string EventTypeName { get; private set; }
        public EventStateEnum State { get; set; }
        public int TimesSent { get; set; }
        public DateTime CreationTime { get; private set; }
        public string Content { get; private set; }
    }
}
