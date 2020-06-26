using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JustR.DesktopGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("JustR", new OpenApiInfo
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
            ConfigureConnectionStrings();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.ConfigureExceptionHandler();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/JustR/swagger.json", "JustR");
            });
        }

        private void ConfigureConnectionStrings()
        {
            ServiceConfigurations.MessageServiceUrl = GetConnectionString("MessageServiceUrl");
            ServiceConfigurations.DialogServiceUrl = GetConnectionString("DialogServiceUrl");
            ServiceConfigurations.FriendServiceUrl = GetConnectionString("FriendServiceUrl");
            ServiceConfigurations.ProfileServiceUrl = GetConnectionString("ProfileServiceUrl");

            String GetConnectionString(String connectionKey) => 
                Configuration.GetConnectionString(connectionKey);
        }
    }
}
