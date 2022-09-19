using CqrsFramework.Messages;

namespace CqrsFramework.Queries
{
    /// <summary>
    /// Defines a query.
    /// </summary>
    public interface IQuery<TReturn> : IMessage
    {
    }
}