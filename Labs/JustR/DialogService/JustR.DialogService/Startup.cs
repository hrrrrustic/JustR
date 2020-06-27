using System;
using System.IO;
using System.Reflection;
using JustR.DialogService.Repository;
using JustR.DialogService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;

namespace JustR.DialogService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IDialogRepository, DialogRepository>();
            services.AddScoped<IDialogService, Service.DialogService>();

            services.AddDbContext<DialogDbContext>(options => options.UseSqlServer(DbConfiguration.ConnectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Dialogs", new OpenApiInfo
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
            DbConfiguration.ConnectionString = Configuration.GetConnectionString("LocalDb");
            ServiceConfiguration.MessageServiceUrl = Configuration.GetConnectionString("MessageServiceUrl");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Dialogs/swagger.json", "Dialogs");
            });
        }
    }
}
