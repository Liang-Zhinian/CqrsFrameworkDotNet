using Registration.Application.Interfaces;
using Registration.Application.Services;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;
using Registration.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SaaSEqt.IdentityAccess.Infra.Data.Context;
using SaaSEqt.IdentityAccess.Domain.Services;
using SaaSEqt.IdentityAccess.Domain.Repositories;
using SaaSEqt.IdentityAccess;
using SaaSEqt.IdentityAccess.Infra.Data.Repositories;
using SaaSEqt.IdentityAccess.Infrastructure.Services;
using SaaSEqt.IdentityAccess.Application;

namespace Registration.ClientWebApi.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            RegisterIdentityAccessServices(services);


            // Infra - Data
            RegisterWriteDb(services);

            // App service
            RegisterAppService(services);
        }


        private static void RegisterWriteDb(IServiceCollection services)
        {
            services.AddScoped<ReservationDbContext>();
            //services.AddScoped<IdentityAccessDbContext>();
            //services.AddScoped<ITenantAddressRepository, TenantAddressRepository>();
            services.AddScoped<Registration.Domain.Repositories.Interfaces.ITenantRepository, Registration.Infra.Data.Repositories.TenantRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IServiceItemRepository, ServiceItemRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
        }

        private static void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<SaaSEqt.Common.Domain.Model.IUnitOfWork, SaaSEqt.IdentityAccess.Infra.Data.UoW.UnitOfWork>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        }

        private static void RegisterIdentityAccessServices(IServiceCollection services){
            services
                .AddSingleton<AuthenticationService>(_ => new AuthenticationService(
                _.GetService<SaaSEqt.IdentityAccess.Domain.Repositories.ITenantRepository>(),
                _.GetService<IUserRepository>(),
                _.GetService<IEncryptionService>()))
                .AddSingleton<GroupMemberService>(_ => new GroupMemberService(
                    _.GetService<IUserRepository>(),
                    _.GetService<IGroupRepository>()))
                .AddSingleton<TenantProvisioningService>(_ => new TenantProvisioningService(
                _.GetService<SaaSEqt.IdentityAccess.Domain.Repositories.ITenantRepository>(),
                _.GetService<IUserRepository>(),
                _.GetService<IRoleRepository>()))
                .AddSingleton<SaaSEqt.IdentityAccess.Domain.Repositories.ITenantRepository, SaaSEqt.IdentityAccess.Infra.Data.Repositories.TenantRepository>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IRoleRepository, RoleRepository>()
                .AddSingleton<IGroupRepository, GroupRepository>()
                .AddSingleton<IEncryptionService, MD5EncryptionService>()
                .AddSingleton<IdentityApplicationService>(s => new IdentityApplicationService(
                    s.GetService<SaaSEqt.Common.Domain.Model.IUnitOfWork>(),
                    s.GetService<AuthenticationService>(),
                    s.GetService<GroupMemberService>(),
                    s.GetService<IGroupRepository>(),
                    s.GetService<TenantProvisioningService>(),
                    s.GetService<SaaSEqt.IdentityAccess.Domain.Repositories.ITenantRepository>(),
                    s.GetService<IUserRepository>()
                ));
        }
    }
}
