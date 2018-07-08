using System;
using System.Collections.Generic;
using CqrsFramework.Events;
using SaaSEqt.Common.Domain.Model;
using SaaSEqt.IdentityAccess.Contracts.IntegrationEvents.Tenant;
using SaaSEqt.IdentityAccess.Contracts.IntegrationEvents.User;
using SaaSEqt.IdentityAccess.Domain.Entities;
using SaaSEqt.IdentityAccess.Domain.Events.Identity.Tenant;
using SaaSEqt.IdentityAccess.Domain.Repositories;

namespace SaaSEqt.IdentityAccess.Application
{
    public class IdentityAccessEventProcessor
    {
        //private readonly ILifetimeScope _autofac;
        readonly IEventPublisher _eventPublisher;
        readonly IGroupRepository groupRepository;
        readonly ITenantRepository tenantRepository;
        readonly IUserRepository userRepository;
        readonly IEventStore eventStore;

        public IdentityAccessEventProcessor(IEventStore eventStore,
                                            IEventPublisher eventPublisher,
                                            IGroupRepository groupRepository,
                                            ITenantRepository tenantRepository,
                                            IUserRepository userRepository
                                            /*, ILifetimeScope autofac*/)
        {
            this.eventStore = eventStore;
            //_autofac = autofac;
            _eventPublisher = eventPublisher;
            this.groupRepository = groupRepository;
            this.tenantRepository = tenantRepository;
            this.userRepository = userRepository;
        }

        public void Listen()
        {
            DomainEventPublisher.Instance.Subscribe(domainEvent =>
                {
                    //using (var scope = _autofac.BeginLifetimeScope("IdentityAccessEventProcessor"))
                    //{
                    Console.WriteLine("Persisting domain event.");
                    //this.eventStore.Save(domainEvent);
                    //}

                    // to do: publish integration events

                    if (domainEvent is TenantProvisioned)
                    {
                        Console.WriteLine("To Do: TenantProvisionedEvent.");
                        TenantProvisioned evt = domainEvent as TenantProvisioned;
                        var tenant = tenantRepository.Get(new TenantId(evt.TenantId));

                        TenantProvisionedIntegrationEvent tenantProvisionedEvent = new TenantProvisionedIntegrationEvent(
                            new TenantId(evt.TenantId),
                            evt.Name,
                            evt.Description,
                            evt.Active
                        );

                        eventStore.Save(new List<IEvent> { tenantProvisionedEvent });
                        _eventPublisher.Publish<TenantProvisionedIntegrationEvent>(tenantProvisionedEvent);
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


                    if (domainEvent is UserRegisteredIntegrationEvent)
                    {
                        Console.WriteLine("To Do: UserRegistered.");

                        UserRegisteredIntegrationEvent evt = domainEvent as UserRegisteredIntegrationEvent;
                        TenantId tenantId = new TenantId(evt.TenantId);
                        var user = userRepository.UserWithUsername(tenantId, evt.Username);

                        UserRegisteredIntegrationEvent userRegisteredIntegrationEvent = new UserRegisteredIntegrationEvent(
                                new TenantId(evt.TenantId),
                                user.Id,
                                user.Username,
                                user.Person.Name,
                                user.Person.EmailAddress
                            );

                        eventStore.Save(new List<IEvent> { userRegisteredIntegrationEvent });
                        _eventPublisher.Publish<UserRegisteredIntegrationEvent>(userRegisteredIntegrationEvent);
                        return;
                    }

                    if (domainEvent is UserEnablementChangedIntegrationEvent)
                    {
                        Console.WriteLine("To Do: UserEnablementChanged.");
                        return;
                    }

                    if (domainEvent is PersonNameChangedIntegrationEvent)
                    {
                        Console.WriteLine("To Do: PersonNameChanged.");
                        return;
                    }

                    if (domainEvent is PersonContactInformationChangedIntegrationEvent)
                    {
                        Console.WriteLine("To Do: PersonContactInformationChanged.");
                        return;
                    }
                });

        }
    }
}
