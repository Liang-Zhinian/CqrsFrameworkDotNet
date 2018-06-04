using CqrsFramework.Domain;
using CqrsFramework.Tests.Substitutes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsFramework.Tests.Substitutes
{
    public class TestRepository : IRepository
    {
        public AggregateRoot Saved { get; private set; }

        public T Get<T>(Guid aggregateId) where T : AggregateRoot
        {
            var obj = (T)Activator.CreateInstance(typeof(T), true);
            obj.LoadFromHistory(new[] { new TestAggregateDidSomething { Id = aggregateId, Version = 1 } });
            return obj;
        }

        public void Save<T>(T aggregate, int? expectedVersion = default(int?)) where T : AggregateRoot
        {
            Saved = aggregate;

            if (expectedVersion == 100)
            {
                throw new Exception();
            }
        }
    }
}
