﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WorkerRoleCommandProcessor.BackgroundTasks
{
    public class GracePeriodManagerService
       : BackgroundService
    {
        private readonly ILogger<GracePeriodManagerService> _logger;
        //private readonly OrderingBackgroundSettings _settings;

        //private readonly IEventBus _eventBus;

        //public GracePeriodManagerService(IOptions<OrderingBackgroundSettings> settings,
        //                                 IEventBus eventBus,
        //                                 ILogger<GracePeriodManagerService> logger)
        //{
        //    //Constructor’s parameters validations...      
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"GracePeriodManagerService is starting.");

            stoppingToken.Register(() =>
                    _logger.LogDebug($" GracePeriod background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"GracePeriod task doing background work.");

                // This eShopOnContainers method is quering a database table 
                // and publishing events into the Event Bus (RabbitMS / ServiceBus)
                //CheckConfirmedGracePeriodOrders();

                //await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
            }

            _logger.LogDebug($"GracePeriod background task is stopping.");
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
        }
    }
}
