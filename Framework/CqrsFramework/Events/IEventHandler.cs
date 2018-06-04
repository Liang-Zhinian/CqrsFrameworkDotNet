using CqrsFramework.Messages;

namespace CqrsFramework.Events
{
    public interface IEventHandler<T> : IHandler<T> where T : IEvent
    {
        
    }
}
