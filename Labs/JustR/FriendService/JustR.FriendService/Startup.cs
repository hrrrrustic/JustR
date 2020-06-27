using System;
using System.IO;
using System.Reflection;
using JustR.FriendService.Repository;
using JustR.FriendService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;

namespace JustR.FriendService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<Compiler, SqlServerCompiler>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendService, Service.FriendService>();

            services.AddDbContext<FriendDbContext>(options => options.UseSqlServer(DbConfiguration.ConnectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Friends", new OpenApiInfo
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

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Friends/swagger.json", "Friends");
            });
        }
    }
}