using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Application.Interfaces;
using Registration.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Registration.Domain.Repositories.Interfaces;
using Registration.Domain.ReadModel;
using CqrsFramework.Domain;
using System.Linq;

namespace Registration.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ISession _session;
        //private readonly ITenantAddressRepository _tenantAddressRepository;
        //private readonly ITenantContactRepository _tenantContactRepository;
        //private readonly IdentityApplicationService _identityApplicationService;
        private readonly ILocationRepository _locationRepository;
        //private readonly IServiceCategoryRepository _serviceCategoryRepository;
        //private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public LocationService(ISession session, 
                             IMapper mapper,
                             //ITenantAddressRepository tenantAddressRepository,
                             //ITenantContactRepository tenantContactRepository,
                          //IServiceCategoryRepository serviceCategoryRepository,
                          //IServiceRepository serviceRepository,
                          ILocationRepository locationRepository
                             //IdentityApplicationService identityApplicationService
                              )
        {
            _session = session;
            _mapper = mapper;
            //_tenantAddressRepository = tenantAddressRepository;
            //_tenantContactRepository = tenantContactRepository;
            //_identityApplicationService = identityApplicationService;
            //_serviceCategoryRepository = serviceCategoryRepository;
            //_serviceRepository = serviceRepository;
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
                TenantId = domainLocation.TenantId,
                //BusinessID = domainLocation.BusinessID,

                //BusinessDescription = domainLocation.BusinessDescription,

                //Name = domainLocation.Name,

                //Description = domainLocation.Description,

                //ImageUrl = domainLocation.ImageUrl,

                //PrimaryTelephone = domainLocation.PrimaryTelephone,

                //SecondaryTelephone = domainLocation.SecondaryTelephone,

                //City = domainLocation.PostalAddress.City,

                //CountryCode = domainLocation.PostalAddress.CountryCode,

                //PostalCode = domainLocation.PostalAddress.PostalCode,

                //StateProvince = domainLocation.PostalAddress.StateProvince,

                //StreetAddress = domainLocation.PostalAddress.StreetAddress,

                //StreetAddress2 = domainLocation.PostalAddress.StreetAddress2,

                //AdditionalLocationImages = (from img in domainLocation.AdditionalLocationImages
                                            //select img.ImageUrl).ToList()

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
                       TenantId = domainLocation.TenantId,
                       //BusinessID = domainLocation.BusinessID,

                       //BusinessDescription = domainLocation.BusinessDescription,

                       //Name = domainLocation.Name,

                       //Description = domainLocation.Description,

                       //ImageUrl = domainLocation.ImageUrl,

                       //PrimaryTelephone = domainLocation.PrimaryTelephone,

                       //SecondaryTelephone = domainLocation.SecondaryTelephone,

                       //City = domainLocation.PostalAddress.City,

                       //CountryCode = domainLocation.PostalAddress.CountryCode,

                       //PostalCode = domainLocation.PostalAddress.PostalCode,

                       //StateProvince = domainLocation.PostalAddress.StateProvince,

                       //StreetAddress = domainLocation.PostalAddress.StreetAddress,

                       //StreetAddress2 = domainLocation.PostalAddress.StreetAddress2,

                       //AdditionalLocationImages = (from img in domainLocation.AdditionalLocationImages
                                                   //select img.ImageUrl).ToList()

                   };

        }

        public void AddLocation(LocationViewModel location){
            //var domainLocation = new Location(location.TenantId);

            //domainLocation.TenantId = location.TenantId;
            //domainLocation.BusinessID = location.BusinessID;

            //domainLocation.BusinessDescription = location.BusinessDescription;

            //domainLocation.Name = location.Name;

            //domainLocation.Description = location.Description;

            //domainLocation.ImageUrl = location.ImageUrl;

            //domainLocation.PrimaryTelephone = location.PrimaryTelephone;

            //domainLocation.SecondaryTelephone = location.SecondaryTelephone;

            //PostalAddress postalAddress = new PostalAddress
            //{
            //    City = location.City,

            //    CountryCode = location.CountryCode,

            //    PostalCode = location.PostalCode,

            //    StateProvince = location.StateProvince,

            //    StreetAddress = location.StreetAddress,

            //    StreetAddress2 = location.StreetAddress2
            //};

            //List<LocationImage> additionalLocationImages = (from img in location.AdditionalLocationImages
            //                                                select 
            //                                                new LocationImage(domainLocation.Id, domainLocation.TenantId, img)
            //                                               ).ToList();
            //domainLocation.PostalAddress = postalAddress;
            //domainLocation.AdditionalLocationImages = additionalLocationImages;


            //_locationRepository.Add(domainLocation);
            //_locationRepository.SaveChanges();
        }
    }
}
