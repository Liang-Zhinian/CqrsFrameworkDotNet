using CqrsFramework.Domain;

namespace SonicService.ReservationService.WriteModel.Handlers
{
    public abstract class CommandHandlerWithSession
    {
        protected readonly ISession _session;

        public CommandHandlerWithSession(ISession session)
        {
            _session = session;
        }

        public void AddToSession(AggregateRoot aggregate)
        {
            _session.Add(aggregate);
        }

        public void CommitSession()
        {
            _session.Commit();
        }
    }
}
