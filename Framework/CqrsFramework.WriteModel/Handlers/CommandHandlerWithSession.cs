using CqrsFramework.Domain;

namespace CqrsFramework.WriteModel.Handlers
{
    public class CommandHandlerWithSession
    {
        private readonly ISession _session;

        public CommandHandlerWithSession(ISession session)
        {
            _session = session;
        }
    }
}
