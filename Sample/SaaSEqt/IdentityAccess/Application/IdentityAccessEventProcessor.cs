using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Events;
using SaaSEqt.Common.Domain.Model;
using Autofac;

namespace SaaSEqt.IdentityAccess.Application
{
    public class IdentityAccessEventProcessor
    {
        //private readonly ILifetimeScope _autofac;

        public IdentityAccessEventProcessor(IEventStore eventStore/*, ILifetimeScope autofac*/)
        {
            this.eventStore = eventStore;
            //_autofac = autofac;
        }

        readonly IEventStore eventStore;

        public void Listen()
        {
            DomainEventPublisher.Instance.Subscribe(domainEvent =>
                {
                    //using (var scope = _autofac.BeginLifetimeScope("IdentityAccessEventProcessor"))
                    //{
                    Console.WriteLine("Persisting domain event.");
                    this.eventStore.Append(domainEvent);
                    //}
                });

        }
    }
}
