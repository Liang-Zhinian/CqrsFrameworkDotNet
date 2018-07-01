using System;
using AutoMapper;
using SaaSEqt.eShop.Site.Api.ViewModel;
using SaaSEqt.eShop.Site.Api.Model;

namespace SaaSEqt.eShop.Site.Api.AutoMapper
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
