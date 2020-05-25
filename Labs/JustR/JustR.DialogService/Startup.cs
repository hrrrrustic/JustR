using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JustR.DialogService.Repository;
using JustR.DialogService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using Microsoft.Extensions.Configuration;

namespace JustR.DialogService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<Compiler, SqlServerCompiler>();
            services.AddScoped<IDialogRepository, DialogRepository>();
            services.AddScoped<IDialogService, Service.DialogService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("JustR.DialogService", new OpenApiInfo
                {
                    Title = "JustR API",
                    Version = "0.1.0"
                });
                String xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                String xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DbConfiguration.ConnectionString = Configuration.GetConnectionString("LocalDb");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/JustR.DialogService/swagger.json", "JustR.DialogService");
            });
        }
    }
}
