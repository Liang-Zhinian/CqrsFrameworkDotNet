using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Domain.Repositories.Interfaces;
using Business.Domain.Models.Security;

namespace Business.Application.Services.Security
{
    public class TenantService : ITenantAppService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(IMapper mapper,
                             ITenantRepository tenantRepository)
        {
            _mapper = mapper;
            _tenantRepository = tenantRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TenantViewModel> GetAll()
        {
            var list = _tenantRepository.GetAll();
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
            var tenant = _mapper.Map<Tenant>(tenantViewModel);
            _tenantRepository.Add(tenant);
            _tenantRepository.SaveChanges();
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
