using CqrsFramework.Events;
using System.Collections.Generic;

namespace SonicService.ReservationService.ReadModel.Factories
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : IEvent;
    }
}
