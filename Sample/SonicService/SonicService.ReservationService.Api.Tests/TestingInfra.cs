using CqrsFramework.Bus;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using CqrsFramework.Messages;
using KellermanSoftware.CompareNetObjects;
using SonicService.ReservationService.WriteModel;
using SonicService.ReservationService.WriteModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace SonicService.ReservationService.Api.Tests
{
    public abstract class TestBase
    {
        public abstract Dictionary<Guid, List<IEvent>> GivenTheseEvents();
        public abstract object WhenThisHappens();
        public virtual IEnumerable<object> TheseEventsShouldOccur() { yield break; }
        public virtual Exception ThisExceptionShouldOccur() { return null; }
        public abstract void RegisterHandler(InProcessBus bus, IRepository repo);

        [Fact]
        public void Test()
        {
            var newMessages = new List<object>();
            var bus = new InProcessBus();
            bus.RegisterHandler<IMessage>(newMessages.Add);

            var eventStore = new InMemoryEventStore(bus, GivenTheseEvents());
            var repository = new DomainRepository(eventStore);

            RegisterHandler(bus, repository);


            try
            {
                bus.Send<ICommand>((ICommand)WhenThisHappens());
            }
            catch (Exception e)
            {
                var expectedException = ThisExceptionShouldOccur();
                if (expectedException == null)
                    Assert.False(true, e.Message);

                if (expectedException.GetType().IsAssignableFrom(e.GetType()))
                {
                    Assert.Equal(expectedException.Message, e.Message);
                    return;
                }

                Assert.False(true, string.Format("Expected exception of type {0} with message {1} but got exception of type {2} with message {3}", expectedException.GetType(), expectedException.Message, e.GetType(), e.Message));
            }

            var expectedEvents = TheseEventsShouldOccur().ToList();

            var comparer = new CompareObjects();

            if (!comparer.Compare(expectedEvents, newMessages))
            {
                Assert.False(true, comparer.DifferencesString);
            }
        }
    }
}

