using System;
using System.IO;
using System.Reflection;
using JustR.DialogService.InternalApi;
using JustR.FriendService.InternalApi;
using JustR.MessageService.InternalApi;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;

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
            services.AddDiscoveryClient(Configuration);

            services
                .AddHttpClient("ProfileService", k =>
                {
                    k.BaseAddress = new Uri("http://ProfileService/api/Profile/");
                })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
                .AddTypedClient<IProfileApiProvider, HttpProfileApiProvider>();

            services.AddHttpClient("DialogService", k =>
                {
                    k.BaseAddress = new Uri("http://DialogService/api/Dialog/");
                })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
                .AddTypedClient<IDialogApiProvider, HttpDialogApiProvider>();

            services.AddHttpClient("FriendService", k =>
                {
                    k.BaseAddress = new Uri("http://FriendService/api/Friend/");
                })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
                .AddTypedClient<IFriendApiProvider, HttpFriendApiProvider>();

            services.AddHttpClient("MessageService", k =>
                {
                    k.BaseAddress = new Uri("http://MessageService/api/Message/");
                })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
                .AddTypedClient<IMessageApiProvider, HttpMessageApiProvider>();

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.ConfigureExceptionHandler();
            app.UseDiscoveryClient();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/JustR/swagger.json", "JustR");
            });
        }
    }
}
