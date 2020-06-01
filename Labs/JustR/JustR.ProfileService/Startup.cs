using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JustR.ProfileService.Repository;
using JustR.ProfileService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;

namespace JustR.ProfileService
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

            services.AddScoped<Compiler, SqlServerCompiler>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, Service.ProfileService>();

            services.AddDbContext<ProfileDbContext>(options => options.UseSqlServer(DbConfiguration.ConnectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Profile", new OpenApiInfo
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
                c.SwaggerEndpoint("/swagger/Profile/swagger.json", "Profile");
            });
        }
    }
}
