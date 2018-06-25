using System;
using System.Collections.Generic;
using System.Linq;
using Registration.Application.Interfaces;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Application.Services
{
    public class TenantService: ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(
                             ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public IEnumerable<Tenant> GetTenants()
        {
            var list = _tenantRepository.Find(_ => true);

            return from t in list
                   select new Tenant
                   {
                       Id = t.Id,
                       Name = t.Name,
                       Description = t.Description,
                       Email = t.Email,
                       PrimaryTelephone = t.PrimaryTelephone,
                       SecondaryTelephone = t.SecondaryTelephone,
                       State = t.StateProvince,
                       City = t.City,
                       Street = t.StreetAddress,
                       Street2 = t.StreetAddress2,
                       Country = t.CountryCode,
                       PostalCode = t.PostalCode,
                   };
        }
    }
}
