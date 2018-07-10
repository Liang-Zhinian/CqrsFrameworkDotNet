using System;
using System.Data.Common;
using System.Threading.Tasks;
using CqrsFramework.Events;
using CqrsFramework.EventStore.MySqlDB.Services;
using CqrsFramework.EventStore.MySqlDB.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SaaSEqt.IdentityAccess.Infra.Data.Context;

namespace SaaSEqt.IdentityAccess.Application
{
    public class IdentityAccessIntegrationEventService : IIdentityAccessIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventPublisher _eventBus;
        private readonly IdentityAccessDbContext _context;
        private readonly IIntegrationEventLogService _eventLogService;

        public IdentityAccessIntegrationEventService(IEventPublisher eventBus, 
                                                     IdentityAccessDbContext context,
                                       Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_context.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IEvent evt)
        {
            await _eventLogService.SaveEventAsync(evt, _context.Database.CurrentTransaction.GetDbTransaction());
            await _eventBus.Publish(evt);
            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }
    }
}
