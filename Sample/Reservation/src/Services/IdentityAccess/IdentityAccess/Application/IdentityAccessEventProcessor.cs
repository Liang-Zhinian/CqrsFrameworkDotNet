using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaaSEqt.Common.Events;
using SaaSEqt.Common.Domain.Model;

namespace SaaSEqt.IdentityAccess.Application
{
    public class IdentityAccessEventProcessor
    {
        public IdentityAccessEventProcessor(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        readonly IEventStore eventStore;

        public void Listen()
        {
            DomainEventPublisher.Instance.Subscribe(domainEvent => this.eventStore.Append(domainEvent));
        }
    }
}
