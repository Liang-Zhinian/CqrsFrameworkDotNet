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

        public TenantEventHandler(ITenantRepository tenantRepo) : base(){
            _tenantRepo = tenantRepo;
        }

        public void Handle(TenantCreatedEvent message)
        {
            Tenant tenant = new Tenant();
            tenant.Id = message.Id;
            tenant.Name = message.Name;
            tenant.DisplayName = message.DisplayName;
            tenant.Email = message.Email;
            tenant.Email2 = message.Email2;
            tenant.Phone = message.Phone;
            tenant.Phone2 = message.Phone2;
            tenant.Phone3 = message.Phone3;
            tenant.Street = message.Street;
            tenant.Street2 = message.Street2;
            tenant.City = message.City;
            tenant.State = message.State;
            tenant.Country = message.Country;
            tenant.PostalCode = message.PostalCode;
            tenant.ForeignZip = message.ForeignZip;
            tenant.LogoURL = message.LogoURL;
            tenant.PageColor1 = message.PageColor1;
            tenant.PageColor2 = message.PageColor2;
            tenant.PageColor3 = message.PageColor3;
            tenant.PageColor4 = message.PageColor4;


            _tenantRepo.Add(tenant);
            _tenantRepo.SaveChanges();
        }
    }
}