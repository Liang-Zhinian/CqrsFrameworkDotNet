﻿using System;
using System.Data.Common;
using CqrsFramework.Events;
using CqrsFramework.EventStore.IntegrationEventLogEF;
using CqrsFramework.EventStore.IntegrationEventLogEF.Services;
using CqrsFramework.EventStore.IntegrationEventLogEF.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.Common.Events;
using SaaSEqt.IdentityAccess.Infra.Data.Context;

namespace SaaSEqt.IdentityAccess.Infra.Services
{
    public class MySqlEventStore : Common.Events.IEventStore
    {
        private readonly IdentityAccessDbContext _context;
        private readonly IntegrationEventLogContext _integrationEventLogContext;

        public MySqlEventStore(
            IdentityAccessDbContext context
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _integrationEventLogContext = new IntegrationEventLogContext(
                new DbContextOptionsBuilder<IntegrationEventLogContext>()
                .UseMySql(_context.Database.GetDbConnection())
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                    .Options);
        }

        public StoredEvent Append(IDomainEvent domainEvent)
        {
            ResilientTransaction.New(_context)
                                .Execute(() =>
                                {
                                    // Achieving atomicity between original ordering database operation and the IntegrationEventLog thanks to a local transaction
                                    _context.SaveChanges();

                                    DbTransaction transaction = _context.Database.CurrentTransaction.GetDbTransaction();
                        
                                    if (transaction == null)
                                    {
                                        throw new ArgumentNullException("transaction", $"A {typeof(DbTransaction).FullName} is required as a pre-requisite to save the event.");
                                    }

                                    var eventLogEntry = new IntegrationEventLogEntry(Guid.NewGuid(),
                                                                 domainEvent.GetType().FullName,
                                                                 domainEvent.TimeStamp.DateTime,
                                                                 JsonConvert.SerializeObject(domainEvent)
                                                                );
                
                                    eventLogEntry.TimesSent++;
                                    eventLogEntry.State = EventStateEnum.Published;

                                    _integrationEventLogContext.Database.UseTransaction(transaction);
                                    _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);
                                    
                                    return _integrationEventLogContext.SaveChanges();
                                });
            return new StoredEvent(domainEvent.GetType().FullName, domainEvent.TimeStamp.DateTime, JsonConvert.SerializeObject(domainEvent));
        }

        public void Close()
        {
            _integrationEventLogContext.Database.CloseConnection();
        }

        public long CountStoredEvents()
        {
            throw new NotImplementedException();
        }

        public StoredEvent[] GetAllStoredEventsBetween(long lowStoredEventId, long highStoredEventId)
        {
            throw new NotImplementedException();
        }

        public StoredEvent[] GetAllStoredEventsSince(long storedEventId)
        {
            throw new NotImplementedException();
        }
    }
}