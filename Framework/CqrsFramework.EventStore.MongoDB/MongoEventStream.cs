using System;
using MongoDB.Bson;

namespace CqrsFramework.EventStore.MongoDB
{
    public class MongoEventStream
    {
        //EventId, StreamId, Sequence, TimeStamp, EventType, Body
        public Guid CommitId { get; set; }
        public Guid EventSourceId { get; set; }
        public long FromVersion { get; set; }
        public long ToVersion { get; set; }
        public BsonValue Payload
        {
            get;
            set;
        }
    }
}
