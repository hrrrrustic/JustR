using System;
using System.IO;
using System.Reflection;
using JustR.DialogService.Repository;
using JustR.DialogService.Service;
using JustR.MessageService.InternalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;

namespace JustR.DialogService
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

            services.AddScoped<IDialogRepository, DialogRepository>();
            services.AddScoped<IDialogService, Service.DialogService>();

            services.AddDbContext<DialogDbContext>(options =>
                options.UseSqlServer(ServiceConfiguration.DbConnectionString));

            services.AddHttpClient("MessageService",
                    k => { k.BaseAddress = new Uri("http://MessageService/api/Message/"); })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
                .AddTypedClient<IMessageApiProvider, HttpMessageApiProvider>();

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
            ServiceConfiguration.DbConnectionString = Configuration.GetConnectionString("LocalDb");

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseSwagger();
            app.UseDiscoveryClient();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/Dialogs/swagger.json", "Dialogs"); });
        }
    }
}