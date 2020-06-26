using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JustR.NotificationService.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JustR.NotificationService
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddSignalR()
                .AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = null);

            services.AddSingleton<ConnectionManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Notifications", new OpenApiInfo
                {
                    Title = "JustR API",
                    Version = "0.1.0"
                });

                String fileName = Assembly
                    .GetExecutingAssembly()
                    .GetName()
                    .Name;

                String xmlFile = $"{fileName}.xml";
                String xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/Notifications");
                endpoints.MapControllers();
            });


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Notifications/swagger.json", "Notifications");
            });
        }
    }
}
