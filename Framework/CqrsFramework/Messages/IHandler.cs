namespace CqrsFramework.Messages
{
    /// <summary>
    /// A handler handles a message.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<T> where T : IMessage
    {
        void Handle(T message);
    }
}
