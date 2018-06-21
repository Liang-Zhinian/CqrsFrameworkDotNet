using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Domain.Models;
using Business.Domain.Models.Security;
using Business.Domain.Models.ValueObjects;
using Business.Domain.Repositories.Interfaces;
using CqrsFramework.Domain;

namespace Business.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ISession _session;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ISession session, 
                             IMapper mapper,
                          ILocationRepository locationRepository
                              )
        {
            _session = session;
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public LocationViewModel FindLocation(Guid locationId)
        {
            var domainLocation = _locationRepository.Find(locationId);
            var view = new LocationViewModel
            {
                Id = domainLocation.Id,
                TenantId = Guid.Parse(domainLocation.TenantId.Id),
                BusinessID = domainLocation.BusinessID,

                BusinessDescription = domainLocation.BusinessDescription,

                Name = domainLocation.Name,

                Description = domainLocation.Description,

                Image = domainLocation.Image,

                PrimaryTelephone = domainLocation.PrimaryTelephone,

                SecondaryTelephone = domainLocation.SecondaryTelephone,

                City = domainLocation.PostalAddress.City,

                CountryCode = domainLocation.PostalAddress.CountryCode,

                PostalCode = domainLocation.PostalAddress.PostalCode,

                StateProvince = domainLocation.PostalAddress.StateProvince,

                StreetAddress = domainLocation.PostalAddress.StreetAddress,

                StreetAddress2 = domainLocation.PostalAddress.StreetAddress2,

                AdditionalLocationImages = (from img in domainLocation.AdditionalLocationImages
                                            select img.Image).ToList()

            };

            return view;
        }

        public IEnumerable<LocationViewModel> FindLocations()
        {
            var domainLocations = _locationRepository.Find(_ => true);
            return from domainLocation in domainLocations
                   select new LocationViewModel
                   {
                       Id = domainLocation.Id,
                TenantId = Guid.Parse(domainLocation.TenantId.Id),
                       BusinessID = domainLocation.BusinessID,

                       BusinessDescription = domainLocation.BusinessDescription,

                       Name = domainLocation.Name,

                       Description = domainLocation.Description,

                       Image = domainLocation.Image,

                       PrimaryTelephone = domainLocation.PrimaryTelephone,

                       SecondaryTelephone = domainLocation.SecondaryTelephone,

                       City = domainLocation.PostalAddress.City,

                       CountryCode = domainLocation.PostalAddress.CountryCode,

                       PostalCode = domainLocation.PostalAddress.PostalCode,

                       StateProvince = domainLocation.PostalAddress.StateProvince,

                       StreetAddress = domainLocation.PostalAddress.StreetAddress,

                       StreetAddress2 = domainLocation.PostalAddress.StreetAddress2,

                       AdditionalLocationImages = (from img in domainLocation.AdditionalLocationImages
                                                   select img.Image).ToList()

                   };

        }

        public void AddLocation(LocationViewModel location){
            TenantId tenantId = new TenantId(location.TenantId.ToString());
            PostalAddress postalAddress = new PostalAddress
            {
                City = location.City,

                CountryCode = location.CountryCode,

                PostalCode = location.PostalCode,

                StateProvince = location.StateProvince,

                StreetAddress = location.StreetAddress,

                StreetAddress2 = location.StreetAddress2
            };
            var domainLocation = new Location(tenantId,
                                              location.TenantId,
                                              location.BusinessDescription,
                                              location.Name,
                                              location.Description,
                                              location.Image,
                                              location.PrimaryTelephone,
                                              location.SecondaryTelephone,
                                              postalAddress
                                             );
            

            List<LocationImage> additionalLocationImages = (from img in location.AdditionalLocationImages
                                                            select 
                                                            new LocationImage(domainLocation.Id, Guid.Parse(domainLocation.TenantId.Id), img)
                                                           ).ToList();
            
            domainLocation.AdditionalLocationImages = additionalLocationImages;


            _locationRepository.Add(domainLocation);
            _locationRepository.SaveChanges();
        }
    }
}
