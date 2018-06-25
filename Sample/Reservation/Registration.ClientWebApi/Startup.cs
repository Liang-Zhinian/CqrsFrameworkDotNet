using Registration.Infra.Data.Context;
using Registration.ClientWebApi.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaaSEqt.IdentityAccess.Infra.Data.Context;

namespace Registration.ClientWebApi
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
            var connection = Configuration.GetConnectionString("MySqlConnectionString");
            services.AddDbContext<ReservationDbContext>(options => options.UseMySql(connection));

            var identityAccessConnection = Configuration.GetConnectionString("MySqlConnectionString");
            services.AddDbContext<IdentityAccessDbContext>(options => options.UseMySql(identityAccessConnection));


            services.AddMemoryCache();

            services.AddMvc()
            //全局配置Json序列化处理
            .AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });


            services.AddAutoMapperSetup();

            services.AddCqrsSetup();

            services.AddApplicationSetup();

            services.AddSwaggerSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book2 Client API V1");
                //c.ShowRequestHeaders();
            });

            app.UseMvc();
        }
    }
}
