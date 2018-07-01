using System;
using AutoMapper;
using SaaSEqt.eShop.Site.Api.ViewModel;
using SaaSEqt.eShop.Site.Api.Model;

namespace SaaSEqt.eShop.Site.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<TenantViewModel, Tenant>()
                //.ConstructUsing(c => new Tenant()
                //{
                //    Name = c.Name,
                //    DisplayName = c.DisplayName,
                //    Contact = new TenantContact()
                //    {
                //        Email = c.Email,
                //        Email2 = c.Email2,
                //        Phone = c.Phone,
                //        Phone2 = c.Phone2,
                //        Phone3 = c.Phone3
                //    },
                //    Address = new TenantAddress()
                //    {
                //        Street = c.Street,
                //        Street2 = c.Street2,
                //        ForeignZip = c.ForeignZip,
                //        PostalCode = c.PostalCode,
                //        City = c.City,
                //        State = c.State,
                //        Country = c.Country,
                //    }
                //});
        }
    }

}
