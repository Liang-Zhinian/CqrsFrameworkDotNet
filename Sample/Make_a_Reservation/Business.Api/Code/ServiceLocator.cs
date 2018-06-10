using System;
using System.Collections.Generic;
using System.Linq;
using CqrsFramework.Bus;
using MAR.Application.ReadModel;
using MAR.Domain;
using MAR.Contracts.Commands;
using MAR.Contracts.Events;
using MAR.Application.CommandHandlers;
using MAR.Application.EventHandlers;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using CqrsFramework.Extensions.EventStores;
using MAR.Contracts.Commands.Employees;
using MAR.Contracts.Events.Employees;

namespace MAR.Api.Code
{
    public class ServiceLocator
    {
        private readonly InProcessBus _bus;

        public InProcessBus Bus { get { return _bus; } }

        private static readonly ServiceLocator Config = new ServiceLocator();
        public static ServiceLocator Instance()
        {
            return Config;
        }

        private ServiceLocator()
        {
            _bus = new InProcessBus();
            var eventStore = new SqlEventStore(_bus, "");
            var repository = new Repository(eventStore);
            var session = new Session(repository);

            var employeeCommandHandlers = new EmployeeCommandHandler(session);
            _bus.RegisterHandler<CreateEmployeeCommand>(employeeCommandHandlers.Handle);

            var employeeEventHandlers = new EmployeeEventHandler();
            _bus.RegisterHandler<EmployeeCreatedEvent>(employeeEventHandlers.Handle);

            //var commandService = new AccountApplicationService(repository);
            //_bus.RegisterHandler<RegisterAccountCommand>(commandService.Handle);
            //_bus.RegisterHandler<DebitAccountCommand>(commandService.Handle);
            //_bus.RegisterHandler<UnlockAccountCommand>(commandService.Handle);

            //var infoProjection = new AccountInfoProjection();
            //_bus.RegisterHandler<AccountRegisteredEvent>(infoProjection.Handle);
            //_bus.RegisterHandler<AccountLockedEvent>(infoProjection.Handle);
            //_bus.RegisterHandler<AccountUnlockedEvent>(infoProjection.Handle);

            //var balanceProjection = new AccountBalanceProjection();
            //_bus.RegisterHandler<AccountRegisteredEvent>(balanceProjection.Handle);
            //_bus.RegisterHandler<AccountDebitedEvent>(balanceProjection.Handle);

            //var notification = new NotificationProjection();
            //_bus.RegisterHandler<AccountRegisteredEvent>(notification.Handle);
            //_bus.RegisterHandler<AccountDebitedEvent>(notification.Handle);
            //_bus.RegisterHandler<AccountLockedEvent>(notification.Handle);
            //_bus.RegisterHandler<AccountUnlockedEvent>(notification.Handle);
            //_bus.RegisterHandler<OverdrawAttemptedEvent>(notification.Handle);

            //_readModel = new ReadModelFacade(balanceProjection, infoProjection, notification);

            var events = eventStore.GetAllEventsEver();
            foreach (var @event in events)
            {
                _bus.Publish<IEvent>((IEvent)@event);
            }
            
        }
    }
}