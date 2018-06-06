using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CqrsFramework.Events;
using MongoDB;
using MongoDB.Driver;

namespace CqrsFramework.EventStore.MongoDB
{
    public class MongoDBEventStore : IEventStore
    {

        /*************** install Mongo DB on MacOS *****************
         * 1. brew install mongodb
         * 2. sudo mongod --config /usr/local/etc/mongod.conf
         * net.port: 27017
         * net.bind_ip: 127.0.0.1
         * systemLog.path: /var/log/mongodb/mongodb.log
         * storage.dbpath: /var/lib/mongodb
         * 3. connect: mongo
         * 4. create admin:
         *      use admin
         *      db.createUser({
         *          user:"root",
         *          pwd:"password",
         *          roles:[{role:"root",db:"admin"}]
         *      })
         * 
         ***********************************************************/

        /// <summary>
        /// The default data uri that points to a local Mongo DB.
        /// </summary>
        protected const string DEFAULT_DATABASE_URI = "mongodb://127.0.0.1:27017";

        private readonly IMongoDatabase _database;
        private readonly IEventPublisher _publisher;

        /// <summary>
        /// The error code
        /// </summary>
        protected const string CONCURRENCY_ERROR_CODE = "E1100";


        public MongoDBEventStore(IEventPublisher publisher, string connectionString = DEFAULT_DATABASE_URI)
        {
            _publisher = publisher;
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("EventStore");
        }

        public void Save(IEvent @event)
        {
            IEnumerable<object> domainEvents = new IEvent[] { @event };

            var eventsCollection = _database.GetCollection<object>("events");
            eventsCollection.InsertMany(domainEvents);
        }

        public IEnumerable<IEvent> Get(Guid aggregateId, int fromVersion)
        {
            var eventsCollection = _database.GetCollection<IEvent>("events");
            if (eventsCollection.Count(_=>true) <= 0) return new List<IEvent>();

            var filters = new List<FilterDefinition<IEvent>>();

            FilterDefinition<IEvent> filter = Builders<IEvent>.Filter.Eq("Id", aggregateId);
            filters.Add(filter);
            filter = Builders<IEvent>.Filter.Gt("Version", fromVersion);
            filters.Add(filter);
            filter = Builders<IEvent>.Filter.And(filters);


            return eventsCollection.Find(filter).ToList();
        }

        public IEnumerable<object> GetAllEventsEver()
        {
            var eventsCollection = _database.GetCollection<object>("events");

            return eventsCollection.AsQueryable();
        }
    }
}