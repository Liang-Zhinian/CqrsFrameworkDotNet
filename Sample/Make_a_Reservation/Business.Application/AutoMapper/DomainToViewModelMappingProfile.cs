using System;
using AutoMapper;
using Business.Application.ViewModels;
using Business.Domain.Models.Security;

namespace Business.Application.AutoMapper
{

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tenant, TenantViewModel>()
                .ConstructUsing(c => new TenantViewModel(c.Id, 
                                                         c.Name,
                                                         c.DisplayName,
                                                         c.TenantContact.Email,
                                                         c.TenantContact.Email2,
                                                         c.TenantContact.Phone,
                                                         c.TenantContact.Phone2,
                                                         c.TenantContact.Phone3,
                                                         c.TenantAddress.State,
                                                         c.TenantAddress.City,
                                                         c.TenantAddress.Street,
                                                         c.TenantAddress.Street2,
                                                         c.TenantAddress.ForeignZip,
                                                         c.TenantAddress.Country,
                                                         c.TenantAddress.PostalCode
                                                         ));
        }
    }
}
