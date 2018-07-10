using Microsoft.Extensions.DependencyInjection;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;
using SaaSEqt.eShop.Site.Api.Application.Services;

namespace SaaSEqt.eShop.Site.Api.Application.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            
            // Infra - Data
            RegisterWriteDb(services);

            // App service
            RegisterAppService(services);
        }


        private static void RegisterWriteDb(IServiceCollection services)
        {
            services.AddScoped<SiteDbContext>();
        }

        private static void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<IBusinessInformationService, BusinessInformationService>();
        }
    }
}
