using System;
using System.Configuration;
using Autofac;
using Business.Application.Interfaces;
using Business.Application.Services;
using Business.Domain.Repositories;
using Business.Domain.Services;
using Business.Infra.Data.Context;
using Business.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SaaSEqt.IdentityAccess;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Domain.Repositories;
using SaaSEqt.IdentityAccess.Domain.Services;
using SaaSEqt.IdentityAccess.Infra.Data.Context;
using SaaSEqt.IdentityAccess.Infra.Data.Repositories;
using SaaSEqt.IdentityAccess.Infrastructure.Services;
using SaaSEqt.Common.Domain.Model;

namespace Business.WebApi.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddApplicationSetup(this IServiceCollection services)
        {
            RegisterIdentityAccessServices(services);
            RegisterIdentityAccessEventProcessor(services);
            ConfigureIdentityAccessEventProcessor(services);

            // Infra - Data
            RegisterWriteDb(services);

            // App service
            RegisterAppService(services);
        }


        private static void RegisterWriteDb(IServiceCollection services)
        {
            //services.AddSingleton<BusinessDbContext>();
            //services.AddSingleton<IdentityAccessDbContext>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<ITenantAddressRepository, TenantAddressRepository>();
            services.AddScoped<ITenantContactRepository, TenantContactRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IServiceItemRepository, ServiceItemRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
        }

        private static void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<SaaSEqt.Common.Domain.Model.IUnitOfWork, SaaSEqt.IdentityAccess.Infra.Data.UoW.UnitOfWork>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<SiteProvisioningService>();
            services.AddTransient<IBusinessInformationService, BusinessInformationService>();
            services.AddTransient<IBusinessInformationQueryService, BusinessInformationQueryService>();
            services.AddTransient<IServiceCategoryService, ServiceCategoryService>();
            services.AddTransient<IServiceCategoryQueryService, ServiceCategoryQueryService>();
        }

        private static void RegisterIdentityAccessServices(IServiceCollection services){
            services
                .AddTransient<AuthenticationService>()
                .AddTransient<GroupMemberService>()
                .AddTransient<TenantProvisioningService>()
                .AddScoped<ITenantRepository, TenantRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IGroupRepository, GroupRepository>()
                .AddTransient<IEncryptionService, MD5EncryptionService>()
                .AddTransient<IdentityApplicationService>()
                .AddSingleton<DomainEventPublisher>();
        }

        private static void RegisterIdentityAccessEventProcessor(IServiceCollection services){
            services
                .AddScoped<SaaSEqt.Common.Events.IEventStore, SaaSEqt.IdentityAccess.Infra.Services.MySqlEventStore>()
                .AddScoped<IdentityAccessEventProcessor>();
        }

        private static void ConfigureIdentityAccessEventProcessor(IServiceCollection services){
            services.BuildServiceProvider().GetService<IdentityAccessEventProcessor>().Listen();
        }
    }
}
