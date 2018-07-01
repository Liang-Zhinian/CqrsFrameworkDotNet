using Catalog.Api.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Api.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            
            // Infra - Data
            RegisterWriteDb(services);

            // App service
            //RegisterAppService(services);
        }


        private static void RegisterWriteDb(IServiceCollection services)
        {
            services.AddScoped<CatalogContext>();
        }

        //private static void RegisterAppService(IServiceCollection services)
        //{
        //    services.AddScoped<IBusinessInformationService, BusinessInformationService>();
        //}
    }
}
