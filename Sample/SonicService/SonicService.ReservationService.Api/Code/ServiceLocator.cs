using System;
using System.Collections.Generic;
using System.Linq;
using CqrsFramework.Bus;
using SonicService.ReservationService.ReadModel;
using SonicService.ReservationService.WriteModel.Domain;
using SonicService.ReservationService.WriteModel.Commands;
using SonicService.ReservationService.WriteModel.Handlers;
using CqrsFramework.Domain;
using SonicService.ReservationService.ReadModel.Handlers;
using SonicService.ReservationService.ReadModel.Events;
using CqrsFramework.Events;
using CqrsFramework.Extensions.EventStores;

namespace SonicService.ReservationService.Code
{
    public class ServiceLocator
    {
        private readonly InProcessBus _bus;
        private readonly ReservationReadModelFacade _readModel;

        public InProcessBus Bus { get { return _bus; } }
        public ReservationReadModelFacade ReadModel { get { return _readModel; } }

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

            var reservationCommandHandlers = new ReservationCommandHandler(session);
            _bus.RegisterHandler<CreatReservationCommand>(reservationCommandHandlers.Handle);

            var reservationEventHandlers = new ReservationEventHandler();
            _bus.RegisterHandler<ReservationCreatedEvent>(reservationEventHandlers.Handle);

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