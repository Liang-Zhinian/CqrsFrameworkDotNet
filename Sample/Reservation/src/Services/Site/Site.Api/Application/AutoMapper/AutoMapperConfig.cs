using System;
using AutoMapper;

namespace SaaSEqt.eShop.Site.Api.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());

                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
