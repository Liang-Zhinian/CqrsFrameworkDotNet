using CqrsFramework.Commands;

namespace CqrsFramework.WriteModel.Factories
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : ICommand;
    }
}
