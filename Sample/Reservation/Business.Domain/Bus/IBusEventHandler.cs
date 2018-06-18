using System;

namespace Business.Domain.Bus
{
	public interface IBusEventHandler
    {
        Type HandlerType { get; }
    }

    public interface IBusEventHandler<T> : IBusEventHandler
    {

        void Handle(T @event);
    }
}
