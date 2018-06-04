using CqrsFramework.Messages;
using System;

namespace CqrsFramework.Bus
{
    public interface IHandlerRegistrar
    {
        void RegisterHandler<T>(Action<T> handler) where T : IMessage;
    }
}
