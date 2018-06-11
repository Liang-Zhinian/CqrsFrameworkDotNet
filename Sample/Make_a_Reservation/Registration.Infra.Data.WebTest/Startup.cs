using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Application.Interfaces;
using Business.Application.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Context;
using Registration.Infra.Data.Repositories;
using Registration.Infra.Data.WebTest.Configurations;

namespace Registration.Infra.Data.WebTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            services.AddAutoMapperSetup();

            RegisterReadDb(services);
            //RegisterAppService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void RegisterReadDb(IServiceCollection services){
            var connection = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<ReservationDbContext>(options => options.UseMySQL(connection));


            services.AddTransient<ReservationDbContext>();
            //services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
            services.AddTransient<IReadModelFacade, ReadModelFacade>();
        }

        private void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<ITenantAppService, TenantService>();
        }
    }
}
