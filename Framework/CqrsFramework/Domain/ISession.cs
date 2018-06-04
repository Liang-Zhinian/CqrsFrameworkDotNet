using System;

namespace CqrsFramework.Domain
{
    /// <summary>
    /// The ISession object acts as a gateway into the data loaded into our Event Store. It is similar to Entity Framework's DataContext class.
    /// </summary>
    public interface ISession
    {
        void Add<T>(T aggregate) where T : AggregateRoot;
        T Get<T>(Guid id, int? expectedVersion = null) where T : AggregateRoot;
        void Commit();
    }
}
