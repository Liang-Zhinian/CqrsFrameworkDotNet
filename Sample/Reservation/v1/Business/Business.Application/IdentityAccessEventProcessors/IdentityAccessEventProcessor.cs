using System;
using Business.Application.Interfaces;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.Common.Events;
using SaaSEqt.IdentityAccess.Domain.Events.Identity.Tenant;
using SaaSEqt.IdentityAccess.Domain.Events.Identity.User;

namespace Business.Application.IdentityAccessEventProcessors
{
    public class IdentityAccessEventProcessor
    {
        readonly IEventStore eventStore;
        readonly IBusinessInformationService _businessInformationService;

        public IdentityAccessEventProcessor(IEventStore eventStore, IBusinessInformationService businessInformationService)
        {
            this.eventStore = eventStore;
            _businessInformationService = businessInformationService;
        }

        public void Listen()
        {
            DomainEventPublisher.Instance.Subscribe(domainEvent =>
                {
                    //using (var scope = _autofac.BeginLifetimeScope("IdentityAccessEventProcessor"))
                    //{
                    Console.WriteLine("Persisting domain event.");
                    this.eventStore.Append(domainEvent);
                    //}

                    // to do: public event
                    if (domainEvent is TenantProvisioned)
                    {
                        Console.WriteLine("To Do: TenantProvisionedEvent.");
                        var evt = domainEvent as TenantProvisioned;
                        _businessInformationService.ProvisionSite(evt.TenantId, evt.Name, evt.Description, evt.Active);
                        return;
                    }
                    if (domainEvent is TenantAdministratorRegistered)
                    {
                        Console.WriteLine("To Do: TenantAdministratorRegistered.");
                        return;
                    }
                    if (domainEvent is TenantActivated)
                    {
                        Console.WriteLine("To Do: TenantActivated.");
                        return;
                    }
                    if (domainEvent is TenantDeactivated)
                    {
                        Console.WriteLine("To Do: TenantDeactivated.");
                        return;
                    }


                    if (domainEvent is UserRegistered)
                    {
                        Console.WriteLine("To Do: UserRegistered.");
                        return;
                    }
                    if (domainEvent is UserEnablementChanged)
                    {
                        Console.WriteLine("To Do: UserEnablementChanged.");
                        return;
                    }
                    if (domainEvent is PersonNameChanged)
                    {
                        Console.WriteLine("To Do: PersonNameChanged.");
                        return;
                    }
                    if (domainEvent is PersonContactInformationChanged)
                    {
                        Console.WriteLine("To Do: PersonContactInformationChanged.");
                        return;
                    }

                });

        }
    }
}
