using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SaaSEqt.eShop.Site.Api.Application.AutoMapper;

namespace SaaSEqt.eShop.Site.Api.Application.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }
    }
}
