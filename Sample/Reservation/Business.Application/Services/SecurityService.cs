using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Domain.Repositories.Interfaces;
using Business.Domain.Models.Security;
using CqrsFramework.Domain;
using SaaSEqt.IdentityAccess.Application;
using System.Linq;
using SaaSEqt.IdentityAccess.Application.Commands;
using Business.Domain.Models;

namespace Business.Application.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISession _session;
        private readonly ITenantAddressRepository _tenantAddressRepository;
        private readonly ITenantContactRepository _tenantContactRepository;
        private readonly IdentityApplicationService _identityApplicationService;
        //private readonly ILocationRepository _locationRepository;
        //private readonly IServiceCategoryRepository _serviceCategoryRepository;
        //private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public SecurityService(ISession session, 
                             IMapper mapper,
                             ITenantAddressRepository tenantAddressRepository,
                             ITenantContactRepository tenantContactRepository,
                          //IServiceCategoryRepository serviceCategoryRepository,
                          //IServiceRepository serviceRepository,
                          //ILocationRepository locationRepository,
                             IdentityApplicationService identityApplicationService)
        {
            _session = session;
            _mapper = mapper;
            _tenantAddressRepository = tenantAddressRepository;
            _tenantContactRepository = tenantContactRepository;
            _identityApplicationService = identityApplicationService;
            //_serviceCategoryRepository = serviceCategoryRepository;
            //_serviceRepository = serviceRepository;
            //_locationRepository = locationRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //public IEnumerable<TenantViewModel> GetAllTenants()
        //{
        //    var list = _tenantRepository.Find(_=>true);
        //    IEnumerable<TenantViewModel> tenants = _mapper.Map<IEnumerable<TenantViewModel>>(list);
        //    return tenants;

        //    //throw new NotImplementedException();
        //}

        //public IList<TenantHistoryData> GetAllHistory(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public TenantViewModel GetTenantById(Guid tenantId)
        {
            var tenant = _identityApplicationService.GetTenant(tenantId.ToString());
            var address = _tenantAddressRepository.Find(_ => _.TenantId.Equals(tenantId)).First();
            var contact = _tenantContactRepository.Find(_ => _.TenantId.Equals(tenantId)).First();

            return new TenantViewModel(tenantId,
                                       tenant.Name,
                                       tenant.Description,
                                       contact.Email,
                                       contact.PrimaryTelephone,
                                       contact.SecondaryTelephone,
                                       address.PostalAddress.StreetAddress,
                                       address.PostalAddress.StreetAddress2,
                                       address.PostalAddress.City,
                                       address.PostalAddress.StateProvince,
                                       address.PostalAddress.CountryCode,
                                       address.PostalAddress.PostalCode);
        }

        public void RegisterTenant(TenantViewModel tenantViewModel, StaffViewModel administratorViewModel)
        {
            ProvisionTenantCommand command
            = new ProvisionTenantCommand(tenantViewModel.Name,
                                         tenantViewModel.Description,
                                         administratorViewModel.FirstName,
                                         administratorViewModel.LastName,
                                         administratorViewModel.EmailAddress,
                                         administratorViewModel.PrimaryTelephone,
                                         administratorViewModel.SecondaryTelephone,
                                         administratorViewModel.AddressStreetAddress,
                                         administratorViewModel.AddressCity,
                                         administratorViewModel.AddressStateProvince,
                                         administratorViewModel.AddressPostalCode,
                                         administratorViewModel.AddressCountryCode
                                        );
            var tenant = _identityApplicationService.ProvisionTenant(command);

            var tenantAddress = new TenantAddress
            {
                PostalAddress = new Domain.Models.ValueObjects.PostalAddress
                {
                    City = tenantViewModel.City,
                    CountryCode = tenantViewModel.Country,
                    PostalCode = tenantViewModel.PostalCode,
                    StateProvince = tenantViewModel.State,
                    StreetAddress = tenantViewModel.Street,
                    StreetAddress2 = tenantViewModel.Street2,
                }
            };

            _tenantAddressRepository.Add(tenantAddress);
            _tenantAddressRepository.SaveChanges();

            var tenantContact = new TenantContact(Guid.Parse(tenant.TenantId.Id),
                                                  tenantViewModel.Email,
                                                  tenantViewModel.PrimaryTelephone,
                                                  tenantViewModel.SecondaryTelephone);

            _tenantContactRepository.Add(tenantContact);
            _tenantContactRepository.SaveChanges();
        }

        //public void Remove(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public void UpdateTenant(TenantViewModel tenantViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
