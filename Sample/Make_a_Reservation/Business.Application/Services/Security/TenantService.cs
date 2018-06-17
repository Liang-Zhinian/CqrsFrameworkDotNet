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

namespace Business.Application.Services.Security
{
    public class TenantService : ITenantAppService
    {
        private readonly ISession _session;
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(ISession session, 
                             IMapper mapper,
                             ITenantRepository tenantRepository)
        {
            _session = session;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TenantViewModel> GetAll()
        {
            var list = _tenantRepository.Find(_=>true);
            IEnumerable<TenantViewModel> tenants = _mapper.Map<IEnumerable<TenantViewModel>>(list);
            return tenants;
        }

        public IList<TenantHistoryData> GetAllHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public TenantViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(TenantViewModel tenantViewModel)
        {
            //var tenant = _mapper.Map<Tenant>(tenantViewModel);

            //var tenant = new Tenant
            //{
            //    Name = tenantViewModel.Name,
            //    DisplayName = tenantViewModel.DisplayName
            //};
            //tenant.Contact = new TenantContact(tenant.Id)
            //{
            //    Email = tenantViewModel.Email,
            //    Email2 = tenantViewModel.Email2,
            //    Phone = tenantViewModel.Phone,
            //    Phone2 = tenantViewModel.Phone2,
            //    Phone3 = tenantViewModel.Phone3
            //};
            //tenant.Address = new TenantAddress(tenant.Id)
            //{
            //    Street = tenantViewModel.Street,
            //    Street2 = tenantViewModel.Street2,
            //    ForeignZip = tenantViewModel.ForeignZip,
            //    PostalCode = tenantViewModel.PostalCode,
            //    City = tenantViewModel.City,
            //    State = tenantViewModel.State,
            //    Country = tenantViewModel.Country,
            //};
            //_tenantRepository.Register(tenant);

            //_session.Add(tenant);
            //_session.Commit();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TenantViewModel tenantViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
