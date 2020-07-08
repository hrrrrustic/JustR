using System;
using System.IO;
using System.Reflection;
using JustR.MessageService.Repository;
using JustR.MessageService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;

namespace JustR.MessageService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDiscoveryClient(Configuration);

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, Service.MessageService>();

            services.AddDbContext<MessageDbContext>(options =>
                options.UseSqlServer(ServiceConfigurations.DbConnectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Messages", new OpenApiInfo
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
            ServiceConfigurations.DbConnectionString = Configuration.GetConnectionString("LocalDb");
            ServiceConfigurations.NotificationServiceUrl = Configuration.GetConnectionString("NotificationServiceUrl");

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseDiscoveryClient();
            app.UseSwagger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/Messages/swagger.json", "Messages"); });
        }
    }
}