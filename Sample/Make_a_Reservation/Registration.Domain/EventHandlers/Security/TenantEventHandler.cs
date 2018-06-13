using Business.Domain.Events.Security.Tenants;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;
using System;

namespace Registration.Domain.EventHandlers.Security
{
    public class TenantEventHandler : EventHandler,
            IEventHandler<TenantCreatedEvent>
    {
        private readonly ITenantRepository _tenantRepo;
        //private readonly IReadModelFacade _tenantRepo;

        public TenantEventHandler(ITenantRepository tenantRepo) : base(){
            _tenantRepo = tenantRepo;
        }

        //public TenantEventHandler(IReadModelFacade tenantRepo) : base()
        //{
        //    _tenantRepo = tenantRepo;
        //}

        public void Handle(TenantCreatedEvent message)
        {
            Tenant tenant = new Tenant();
            tenant.Id = message.Id.ToString();
            //var profile = message.StaffProfile;
            tenant.Name = message.Name;
            tenant.DisplayName = message.DisplayName;


            _tenantRepo.Add(tenant);
            _tenantRepo.SaveChanges();
            //_tenantRepo.CreateTenant(tenant);
        }
    }
}