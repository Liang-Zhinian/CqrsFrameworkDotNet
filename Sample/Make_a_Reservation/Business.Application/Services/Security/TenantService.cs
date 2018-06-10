using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using CqrsFramework.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Domain.Commands.Security.Tenants;
using Registration.Domain.Repositories.Interfaces;

namespace Business.Application.Services.Security
{
    public class TenantService : ITenantAppService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly ICommandSender Bus;

        public TenantService(IMapper mapper,
                             /*ITenantRepository tenantRepository,*/
                             ICommandSender bus)
        {
            _mapper = mapper;
            //_tenantRepository = tenantRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TenantViewModel> GetAll()
        {
            throw new NotImplementedException();
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
            var registerCommand = _mapper.Map<CreateTenantCommand>(tenantViewModel);
            Bus.Send(registerCommand);
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
