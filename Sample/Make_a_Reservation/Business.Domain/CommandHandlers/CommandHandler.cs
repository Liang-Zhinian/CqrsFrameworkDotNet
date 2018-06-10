using System;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Business.Domain.Commands;
using MediatR;

namespace Business.Domain.CommandHandlers
{
    public class CommandHandler
    {
        protected readonly ISession _session;
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

        protected void NotifyValidationErrors(BaseCommand message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.Publish(new Notification(message.MessageType, error.ErrorMessage));
            }
        }

        public void AddToSession(AggregateRoot aggregate)
        {
            _session.Add(aggregate);
        }

        public void CommitSession()
        {
            try
            {
                _session.Commit();

                //return true;
            }
            catch
            {
                _bus.Publish(new Notification("Commit", "We had a problem during saving your data."));
            }
        }
    }
}
