using Microsoft.Extensions.DependencyInjection;
using Registration.Application.Interfaces;
using Registration.Application.Services;

namespace Registration.Api.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            // App service
            RegisterAppService(services);
        }

        private static void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddTransient<ISiteService, SiteService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IServiceCategoryService, ServiceCategoryService>();
        }

    }
}
