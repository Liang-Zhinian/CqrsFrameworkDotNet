﻿using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Appointment.API.Configurations
{
    public static class SwaggerSupport
    {
        public static void AddSwaggerSupport(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Book2 Appointment Interface Document",
                    Description = "RESTful Appointment API for Book2",
                    TermsOfService = "None",
                    //Contact = new Contact { Name = "Jack Leung", Email = "jackl@atpath.com", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "Appointment.API.xml");
                //c.IncludeXmlComments(xmlPath);

                //  c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
        }
    }
}
