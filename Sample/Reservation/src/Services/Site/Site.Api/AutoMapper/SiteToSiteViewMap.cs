using System;
using AutoMapper;
using SaaSEqt.eShop.Site.Api.ViewModel;
using SaaSEqt.eShop.Site.Api.Model;

namespace SaaSEqt.eShop.Site.Api.AutoMapper
{
    public class SiteToSiteViewMap : Profile
    {
        public SiteToSiteViewMap()
        {
            CreateMap<Model.Site, SiteViewModel>()
                .ConstructUsing(c => new SiteViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Active = c.Active,
                    Logo = c.Branding.Logo,
                    PageColor1 = c.Branding.PageColor1,
                    PageColor2 = c.Branding.PageColor2,
                    PageColor3 = c.Branding.PageColor3,
                    PageColor4 = c.Branding.PageColor4,
                    ContactName = c.ContactInformation.ContactName,
                    PrimaryTelephone = c.ContactInformation.PrimaryTelephone,
                    SecondaryTelephone = c.ContactInformation.SecondaryTelephone,
                    TenantId = c.TenantId.ToString()
                });
        }
    
    }
}
