using Business.Domain.Events.Security.Businesses;
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

            tenant.Contact = new TenantContact()
            {
                Id = new Guid().ToString(),
                Email = message.TenantContact.Email,
                Email2 = message.TenantContact.Email2,
                Phone = message.TenantContact.Phone,
                Phone2 = message.TenantContact.Phone2,
                Phone3 = message.TenantContact.Phone3,
                TenantId = tenant.Id
            };
            tenant.Address = new TenantAddress()
            {
                Id = new Guid().ToString(),
                Street = message.TenantAddress.Street,
                Street2 = message.TenantAddress.Street2,
                State = message.TenantAddress.State,
                City = message.TenantAddress.City,
                Country = message.TenantAddress.Country,
                TenantId = tenant.Id
            };

            _tenantRepo.Add(tenant);
            //_tenantRepo.CreateTenant(tenant);
        }
    }
}