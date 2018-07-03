﻿using System;
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
            //services.AddScoped<BusinessDbContext>();
            //services.AddScoped<IdentityAccessDbContext>();
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
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<SiteProvisioningService>();
            services.AddScoped<IBusinessInformationService, BusinessInformationService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        }

        private static void RegisterIdentityAccessServices(IServiceCollection services){
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
                .AddScoped<ITenantRepository, TenantRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IGroupRepository, GroupRepository>()
                .AddScoped<IEncryptionService, MD5EncryptionService>()
                .AddScoped<IdentityApplicationService>(s => new IdentityApplicationService(
                    s.GetService<SaaSEqt.Common.Domain.Model.IUnitOfWork>(),
                    s.GetService<AuthenticationService>(),
                    s.GetService<GroupMemberService>(),
                    s.GetService<IGroupRepository>(),
                    s.GetService<TenantProvisioningService>(),
                    s.GetService<ITenantRepository>(),
                    s.GetService<IUserRepository>()
                ));
        }

        private static void RegisterIdentityAccessEventProcessor(IServiceCollection services){
            services
                .AddSingleton<SaaSEqt.Common.Events.IEventStore, SaaSEqt.IdentityAccess.Infra.Services.MySqlEventStore>()
                .AddSingleton<IdentityAccessEventProcessor>(sp =>
                {
                    var eventStore = sp.GetRequiredService<SaaSEqt.Common.Events.IEventStore>();
                    var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();

                    return new IdentityAccessEventProcessor(eventStore, iLifetimeScope);
                });
        }

        private static void ConfigureIdentityAccessEventProcessor(IServiceCollection services){
            services.BuildServiceProvider().GetService<IdentityAccessEventProcessor>().Listen();
        }
    }
}