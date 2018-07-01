using IdentityAccess.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using SaaSEqt.IdentityAccess;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Domain.Repositories;
using SaaSEqt.IdentityAccess.Domain.Services;
using SaaSEqt.IdentityAccess.Infra.Data.Context;
using SaaSEqt.IdentityAccess.Infra.Data.Repositories;
using SaaSEqt.IdentityAccess.Infrastructure.Services;

namespace SaaSEqt.IdentityAccess.Api.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            RegisterIdentityAccessRepositories(services);

            RegisterIdentityAccessServices(services);

            // Infra - Data
            RegisterWriteDb(services);

            RegisterAppService(services);

        }

        private static void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<ITenantService, TenantService>();
        }

        private static void RegisterWriteDb(IServiceCollection services)
        {
            services.AddScoped<IdentityAccessDbContext>();
        }

        private static void RegisterIdentityAccessRepositories(IServiceCollection services)
        {
            services
                .AddScoped<ITenantRepository, TenantRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IGroupRepository, GroupRepository>();
        }

        private static void RegisterIdentityAccessServices(IServiceCollection services)
        {
            services
                .AddScoped<AuthenticationService>(_ => new AuthenticationService(
                    _.GetService<ITenantRepository>(),
                    _.GetService<IUserRepository>(),
                    _.GetService<IEncryptionService>()))
                .AddScoped<GroupMemberService>(_ => new GroupMemberService(
                    _.GetService<IUserRepository>(),
                    _.GetService<IGroupRepository>()))
                .AddScoped<TenantProvisioningService>(_ => new TenantProvisioningService(
                    _.GetService<ITenantRepository>(),
                    _.GetService<IUserRepository>(),
                    _.GetService<IRoleRepository>()))
                .AddScoped<IEncryptionService, MD5EncryptionService>()
                .AddScoped<IdentityApplicationService>(s => new IdentityApplicationService(
                    s.GetService<AuthenticationService>(),
                    s.GetService<GroupMemberService>(),
                    s.GetService<IGroupRepository>(),
                    s.GetService<TenantProvisioningService>(),
                    s.GetService<ITenantRepository>(),
                    s.GetService<IUserRepository>()
                ));
        }
    }
}
