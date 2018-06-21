using System;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Events.Security.Tenants;
using Business.Domain.Repositories.Interfaces;
using CqrsFramework.Events;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Application.Commands;
using SaaSEqt.IdentityAccess.Domain.Models;

namespace Business.Application.Services
{
    public class TenantService: ITenantService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IdentityApplicationService _identityApplicationService;
        private readonly ITenantAddressRepository _tenantAddressRepository;
        private readonly ITenantContactRepository _tenantContactRepository;

        public TenantService(IEventPublisher eventPublisher,
                             IdentityApplicationService identityApplicationService,
                             ITenantAddressRepository tenantAddressRepository,
                             ITenantContactRepository tenantContactRepository)
        {
            _eventPublisher = eventPublisher;
            _identityApplicationService = identityApplicationService;
            _tenantAddressRepository = tenantAddressRepository;
            _tenantContactRepository = tenantContactRepository;
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

            Tenant _tenant = _identityApplicationService.ProvisionTenant(command);

            TenantCreatedEvent tenantCreatedEvent = new TenantCreatedEvent(
                Guid.Parse(_tenant.TenantId_Id),
                _tenant.Name,
                _tenant.Description
            );

            _eventPublisher.Publish<TenantCreatedEvent>(tenantCreatedEvent);
        }


    }
}
