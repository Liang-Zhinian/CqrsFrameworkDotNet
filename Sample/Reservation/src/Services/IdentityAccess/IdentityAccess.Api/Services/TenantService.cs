﻿using System;
using CqrsFramework.Events;
using IdentityAccess.Api.Events;
using IdentityAccess.Api.ViewModel;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Application.Commands;

namespace IdentityAccess.Api.Services
{
    public class TenantService: ITenantService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IdentityApplicationService _identityApplicationService;

        public TenantService(IEventPublisher eventPublisher,
                             IdentityApplicationService identityApplicationService)
        {
            _eventPublisher = eventPublisher;
            _identityApplicationService = identityApplicationService;
        }

        public void ProvisionTenant(TenantViewModel tenant, StaffViewModel administrator)
        {
            ProvisionTenantCommand command = new ProvisionTenantCommand(
                        tenant.Name,
                        tenant.Description,
                        administrator.FirstName,
                        administrator.LastName,
                        administrator.EmailAddress,
                        administrator.PrimaryTelephone,
                        administrator.SecondaryTelephone,
                        administrator.AddressStreetAddress,
                        administrator.AddressCity,
                        administrator.AddressStateProvince,
                        administrator.AddressPostalCode,
                        administrator.AddressCountryCode
                    );

            var _tenant = _identityApplicationService.ProvisionTenant(command);

            TenantCreatedEvent tenantCreatedEvent = new TenantCreatedEvent(
                Guid.Parse(_tenant.TenantId_Id),
                _tenant.Name,
                _tenant.Description
            );

            _eventPublisher.Publish<TenantCreatedEvent>(tenantCreatedEvent);
        }

    }
}
