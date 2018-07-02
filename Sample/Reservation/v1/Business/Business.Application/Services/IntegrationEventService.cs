﻿using System;
using System.Data.Common;
using System.Threading.Tasks;
using Business.Domain.Services;
using Business.Infra.Data.Context;
using CqrsFramework.Events;
using CqrsFramework.EventStore.IntegrationEventLogEF.Services;
using CqrsFramework.EventStore.IntegrationEventLogEF.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Application.Services
{
    public class IntegrationEventService : IIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventPublisher _eventBus;
        private readonly BusinessDbContext _context;
        private readonly IIntegrationEventLogService _eventLogService;

        public IntegrationEventService(IEventPublisher eventBus, 
                                       BusinessDbContext context,
        Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_context.Database.GetDbConnection());
        }

        public void PublishThroughEventBus(IEvent evt)
        {
            SaveEventAndContextChanges(evt);
            _eventBus.Publish(evt);
            //_eventLogService.MarkEventAsPublished(evt);
        }

        public async Task PublishThroughEventBusAsync(IEvent evt)
        {
            await SaveEventAndContextChangesAsync(evt);
            _eventBus.Publish(evt);
            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }

        private async Task SaveEventAndContextChangesAsync(IEvent evt)
        {
            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_context)
                .ExecuteAsync(async () => {
                    // Achieving atomicity between original ordering database operation and the IntegrationEventLog thanks to a local transaction
                await _context.SaveChangesAsync();
                await _eventLogService.SaveEventAsync(evt, _context.Database.CurrentTransaction.GetDbTransaction());
                });
        }

        private void SaveEventAndContextChanges(IEvent evt)
        {
            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            ResilientTransaction.New(_context)
                                .Execute(() =>
                                {
                                    // Achieving atomicity between original ordering database operation and the IntegrationEventLog thanks to a local transaction
                                    _context.SaveChanges();
                                    return _eventLogService.SaveEvent(evt, _context.Database.CurrentTransaction.GetDbTransaction());
                                });
        }
    
    }
}
