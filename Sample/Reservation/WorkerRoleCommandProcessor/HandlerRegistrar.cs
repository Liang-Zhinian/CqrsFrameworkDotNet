using System;
using System.Collections.Generic;
using CqrsFramework.Bus;
using CqrsFramework.Messages;
using static WorkerRoleCommandProcessor.ReservationCommandProcessor;

namespace WorkerRoleCommandProcessor
{
    public class HandlerRegistrar : IHandlerRegistrar
    {
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<IMessage, T>(x => handler(x)));
        }
    }
}
