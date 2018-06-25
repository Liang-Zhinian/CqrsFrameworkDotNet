using System;
using System.Linq;
using AutoMapper;
using Business.Application.ViewModels;
using Business.Domain.Entities;

namespace Business.Application.AutoMapper
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
