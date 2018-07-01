using System;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Events.Security.Tenants;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using CqrsFramework.Events;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Application.Commands;

namespace Business.Application.Services
{
    public class TenantService: ITenantService
    {

        private readonly IEventPublisher _eventPublisher;
        private readonly IdentityApplicationService _identityApplicationService;
        private readonly ITenantAddressRepository _tenantAddressRepository;
        private readonly ITenantContactRepository _tenantContactRepository;
        private readonly IBusinessInformationService _businessInformationService;

        public TenantService(IEventPublisher eventPublisher,
                             IdentityApplicationService identityApplicationService,
                             ITenantAddressRepository tenantAddressRepository,
                             ITenantContactRepository tenantContactRepository,
                             IBusinessInformationService businessInformationService)
        {
            _eventPublisher = eventPublisher;
            _identityApplicationService = identityApplicationService;
            _tenantAddressRepository = tenantAddressRepository;
            _tenantContactRepository = tenantContactRepository;
            _businessInformationService = businessInformationService;
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

            _businessInformationService.ProvisionSite(_tenant.TenantId.Id, _tenant.Name,
                                                      _tenant.Description, _tenant.Active);
        }

        public void ModifyTenantAddress(TenantAddressViewModel addressViewModel){
            TenantAddress address = _tenantAddressRepository.Find(addressViewModel.Id); //_eventStoreSession.Get<TenantAddress>(addressViewModel.Id);
            address.ModifyAddress(
                new TenantId(addressViewModel.TenantId.ToString()),
                addressViewModel.StreetAddress,
                addressViewModel.StreetAddress2,
                addressViewModel.City,
                addressViewModel.StateProvince,
                addressViewModel.PostalCode,
                addressViewModel.CountryCode
            );
            //_eventStoreSession.Add(address);
            //_eventStoreSession.Commit();

            _tenantAddressRepository.Update(address);
            _tenantAddressRepository.SaveChanges();
        }

        public void AddTenantAddress(TenantAddressViewModel addressViewModel)
        {
            TenantAddress address = new TenantAddress(
                new TenantId(addressViewModel.TenantId.ToString()),
                new PostalAddress(
                addressViewModel.StreetAddress,
                addressViewModel.StreetAddress2,
                addressViewModel.City,
                addressViewModel.StateProvince,
                addressViewModel.PostalCode,
                    addressViewModel.CountryCode)
            );

            //_eventStoreSession.Add(address);
            //_eventStoreSession.Commit();

            _tenantAddressRepository.Add(address);
            _tenantAddressRepository.SaveChanges();
        }

    }
}
