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
            //CreateMap<Tenant, TenantViewModel>()
                //.ConstructUsing(c => new TenantViewModel(c.Id, 
                                                         //c.Name,
                                                         //c.DisplayName,
                                                         //c.Contact.Email,
                                                         //c.Contact.Email2,
                                                         //c.Contact.Phone,
                                                         //c.Contact.Phone2,
                                                         //c.Contact.Phone3,
                                                         //c.Address.State,
                                                         //c.Address.City,
                                                         //c.Address.Street,
                                                         //c.Address.Street2,
                                                         //c.Address.ForeignZip,
                                                         //c.Address.Country,
                                                         //c.Address.PostalCode
                                                         //));
        }
    }
}
