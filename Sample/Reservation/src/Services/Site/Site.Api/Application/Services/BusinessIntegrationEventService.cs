using System;
using System.Data.Common;
using System.Threading.Tasks;
using Business.Domain.Services;
using Business.Infra.Data.Context;
using CqrsFramework.Events;
using CqrsFramework.EventStore.MySqlDB.Services;
using CqrsFramework.EventStore.MySqlDB.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SaaSEqt.eShop.Site.Api.Application.Services
{
    public class BusinessIntegrationEventService : IBusinessIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventPublisher _eventBus;
        private readonly BusinessDbContext _context;
        private readonly IIntegrationEventLogService _eventLogService;

        public BusinessIntegrationEventService(IEventPublisher eventBus, 
                                       BusinessDbContext context,
                                       Func<DbConnection, CqrsFramework.EventStore.MySqlDB.Services.IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_context.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IEvent evt)
        {
            await SaveEventAndBusinessDbContextChangesAsync(evt);
            await _eventBus.Publish(evt);
            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }

        private async Task SaveEventAndBusinessDbContextChangesAsync(IEvent evt)
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
    }
}
