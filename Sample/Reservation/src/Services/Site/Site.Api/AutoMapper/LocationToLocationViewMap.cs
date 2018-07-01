using System;
using System.Linq;
using AutoMapper;
using SaaSEqt.eShop.Site.Api.ViewModel;
using SaaSEqt.eShop.Site.Api.Model;

namespace SaaSEqt.eShop.Site.Api.AutoMapper
{
    public class LocationToLocationViewMap : Profile
    {
        public LocationToLocationViewMap()
        {
            CreateMap<Location, LocationViewModel>()
                .ConstructUsing(c => new LocationViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,

                    StateProvince = c.PostalAddress?.StateProvince,
                    City = c.PostalAddress?.City,
                    StreetAddress = c.PostalAddress?.StreetAddress,
                    StreetAddress2 = c.PostalAddress?.StreetAddress2,
                    CountryCode = c.PostalAddress?.CountryCode,
                    PostalCode = c.PostalAddress?.PostalCode,
                    Latitude = c.Geolocation?.Latitude,
                    Longitude = c.Geolocation?.Longitude,
                    ContactName = c.ContactInformation?.ContactName,
                    PrimaryTelephone = c.ContactInformation?.PrimaryTelephone,
                    SecondaryTelephone = c.ContactInformation?.SecondaryTelephone,
                    AdditionalLocationImages = (from img in c.AdditionalLocationImages
                                                select img.Image
                ).ToList(),
                    SiteId = c.SiteId

                });
        }
    
    }
}
