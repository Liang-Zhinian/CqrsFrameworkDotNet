using CqrsFramework.Commands;

namespace SonicService.ReservationService.WriteModel.Factories
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : ICommand;
    }
}
