using System;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Registration.Contracts.Commands;
using MediatR;
using System.Threading.Tasks;
using System.Linq;

namespace Registration.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly ISession _session;
        private readonly IEventPublisher _bus;
        private readonly NotificationHandler _notifications;

        public CommandHandler(ISession session, IEventPublisher bus, INotificationHandler<Notification> notifications)
            :this(session)
        {
            _notifications = (NotificationHandler)notifications;
            _bus = bus;
        }

        public CommandHandler(ISession session)
        {
            _session = session;
        }

        protected async Task NotifyValidationErrors(BaseCommand message)
        {
            //foreach (var error in message.ValidationResult.Errors)
            //{
            //    _bus.Publish(new Notification(message.MessageType, error.ErrorMessage));
            //}

            var tasks = message.ValidationResult.Errors.Select(error => _bus.Publish(new Notification(message.MessageType, error.ErrorMessage)));

            await Task.WhenAll(tasks.ToArray());
        }

        public async Task AddToSession(AggregateRoot aggregate)
        {
            await _session.Add(aggregate);
        }

        public async Task CommitSession()
        {
            try
            {
                await _session.Commit();

                //return true;
            }
            catch
            {
                await _bus.Publish(new Notification("Commit", "We had a problem during saving your data."));
            }
        }
    }
}
