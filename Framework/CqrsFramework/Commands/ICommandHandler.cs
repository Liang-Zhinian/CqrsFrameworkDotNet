using CqrsFramework.Messages;

namespace CqrsFramework.Commands
{
    public interface ICommandHandler<T> :IHandler<T> where T : ICommand
    {
    }
}
