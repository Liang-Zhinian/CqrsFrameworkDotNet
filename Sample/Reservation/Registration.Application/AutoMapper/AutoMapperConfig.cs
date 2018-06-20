using System;
using AutoMapper;

namespace Registration.Application.AutoMapper
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
